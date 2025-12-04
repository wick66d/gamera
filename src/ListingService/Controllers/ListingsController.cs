using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using ListingService.Data;
using ListingService.DTOs;
using ListingService.Entities;
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
    public async Task<ActionResult<List<ListingDTO>>> GetAllListings(string date)
    {
        var query = _context.Listings.OrderBy(x => x.Title).AsQueryable();

        if (!string.IsNullOrEmpty(date))
        {
            query = query.Where(x => x.UpdatedAt.CompareTo(DateTime.Parse(date).ToUniversalTime()) > 0);
        }

        return await query.ProjectTo<ListingDTO>(_mapper.ConfigurationProvider).ToListAsync();
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
    [HttpPost]
    public async Task<ActionResult<ListingDTO>> CreateListing(CreateListingDTO listingDTO)
    {
        var listing = _mapper.Map<Listing>(listingDTO);
        listing.SellerId = Guid.NewGuid();
        listing.GameId = Guid.NewGuid();
        _context.Listings.Add(listing);

        var result = await _context.SaveChangesAsync() > 0;

        if(!result) return BadRequest("Problem saving changes");

        return CreatedAtAction(nameof(GetListingById), new {id = listing.ListingId}, _mapper.Map<ListingDTO>(listing));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ListingDTO>> UpdateListing(Guid id, UpdateListingDTO updatedListing)
    {
        var listing = await _context.Listings.FirstOrDefaultAsync(x => x.ListingId == id);
        
        if(listing == null) return NotFound();

        listing.Title = updatedListing.Title ?? listing.Title;
        listing.Description = updatedListing.Description ?? listing.Description;
        listing.MinDeliveryMinutes = updatedListing.MinDeliveryMinutes ?? listing.MinDeliveryMinutes;
        listing.MaxDeliveryMinutes = updatedListing.MaxDeliveryMinutes ?? listing.MaxDeliveryMinutes;

        var result = await _context.SaveChangesAsync() > 0;

        if(!result) return BadRequest("Error saving changes");

        return Ok();
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult<ListingDTO>> DeleteListing(Guid id)
    {
        var listing = await _context.Listings.FindAsync(id);

        if(listing == null) return NotFound();

        _context.Listings.Remove(listing);

        var result = await _context.SaveChangesAsync() > 0;

        if(!result) return BadRequest("Error saving changes");

        return Ok();
    }
}
