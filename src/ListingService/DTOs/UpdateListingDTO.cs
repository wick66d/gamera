using System;

namespace ListingService.DTOs;

public class UpdateListingDTO
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int? MinDeliveryMinutes { get; set; }
    public int? MaxDeliveryMinutes { get; set; }
}
