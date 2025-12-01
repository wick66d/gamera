using System;
using AutoMapper;
using ListingService.Data;
using ListingService.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ListingService.Controllers;

[ApiController]
[Route("api/listings")]
public class ListingsController : ControllerBase
{
    private readonly ListingDbContext _context;
    private readonly IMapper _mapper;

    public ListingsController(ListingDbContext context, IMapper mapper)
    {
        this._context = context;
        this._mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<ListingDTO>>> GetAllListingsAsync()
    {
        var listings = await _context.Listings.ToListAsync();
        return _mapper.Map<List<ListingDTO>>(listings);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<ListingDTO>> GetListingById(Guid id)
    {
        var listing = await _context.Listings.FirstOrDefaultAsync(x => x.ListingId == id);
        if(listing == null)
        {
        return NotFound();
        }        
        return _mapper.Map<ListingDTO>(listing);
    }
}
