using System;
using ListingService.Models;
using Microsoft.EntityFrameworkCore;

namespace ListingService.Data;

public class ListingDbContext : DbContext
{
    public ListingDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Listing> Listings { get; set; }
}
