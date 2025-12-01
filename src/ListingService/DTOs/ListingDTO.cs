using System;

namespace ListingService.DTOs;

public class ListingDTO
{
    public Guid ListingId { get; set; }
    public Guid SellerId { get; set; }
    public Guid GameId { get; set; }
    public string GameName { get; set; }
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } //gold, account, boosting
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal PriceAmount { get; set; }
    public string Currency { get; set; }
    public bool IsStackable { get; set; }
    public int QuantityAvailable { get; set; }
    public string DeliveryType { get; set; }
    public int MinDeliveryMinutes { get; set; }
    public int MaxDeliveryMinutes { get; set; }
    public string Status { get; set; }
    public DateTime CreatedAt { get; set; }

}
