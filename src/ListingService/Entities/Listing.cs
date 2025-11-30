using System;
using ListingService.Entities;

namespace ListingService.Models;

public class Listing
{
    public Guid ListingId { get; set; }
    public Guid SellerId { get; set; }
    public Guid GameId { get; set; }
    public required string GameName { get; set; }
    public int CategoryId { get; set; }
    public required string CategoryName { get; set; } //gold, account, boosting
    public required string Title { get; set; }
    public required string Description { get; set; }
    public decimal PriceAmount { get; set; }
    public required string Currency { get; set; }
    public bool IsStackable { get; set; }
    public int QuantityAvailable { get; set; }
      public DeliveryType DeliveryType { get; set; }
    public int? MinDeliveryMinutes { get; set; }
    public int? MaxDeliveryMinutes { get; set; }
    public Status Status { get; set; } = Status.Draft;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;


}
