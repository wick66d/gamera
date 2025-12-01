using System;

namespace ListingService.DTOs;

public class UpdateListingDTO
{
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal PriceAmount { get; set; }
    public string Currency { get; set; }
    public int QuantityAvailable { get; set; }
    public string DeliveryType { get; set; }
    public int MinDeliveryMinutes { get; set; }
    public int MaxDeliveryMinutes { get; set; }
}
