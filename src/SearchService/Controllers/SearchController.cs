using Microsoft.AspNetCore.Mvc;
using MongoDB.Entities;
using SearchService.Models;
using SearchService.RequestHelpers;

namespace SearchService.Controllers;

[ApiController]
[Route("api/search")]
public class SearchController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<Listing>>> SearchItems([FromQuery]SearchParams searchParams)
    {
        var query = DB.PagedSearch<Listing, Listing>();

        if (!string.IsNullOrEmpty(searchParams.SearchTerm))
        {
            query.Match(Search.Full, searchParams.SearchTerm).SortByTextScore();
        }

        query = searchParams.OrderBy switch
        {
            "title" => query.Sort(x => x.Ascending(a => a.Title)),
            "new" => query.Sort(x => x.Descending(a => a.CreatedAt)),
            _ => query.Sort(x => x.Ascending(a => a.PriceAmount)),
        };



        if (!string.IsNullOrEmpty(searchParams.CategoryName))
        {
            query.Match(x => x.CategoryName == searchParams.CategoryName);
        }

        if (!string.IsNullOrEmpty(searchParams.GameName))
        {
            query.Match(x => x.GameName == searchParams.GameName);
        }

        query.PageNumber(searchParams.PageNumber);
        query.PageSize(searchParams.PageSize);

        var result = await query.ExecuteAsync();

        return Ok(new
        {
            result = result.Results,
            pageCount = result.PageCount,
            totalCount = result.TotalCount
        });
    }
}
