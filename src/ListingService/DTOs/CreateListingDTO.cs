using System;
using System.ComponentModel.DataAnnotations;

namespace ListingService.DTOs;

public class CreateListingDTO
{
    [Required]
    public string GameName { get; set; }
    [Required]
    public int CategoryId { get; set; }
    [Required]
    public string CategoryName { get; set; }
        [Required]
    public string Title { get; set; }
        [Required]
    public string Description { get; set; }
        [Required]
    public decimal PriceAmount { get; set; }
        [Required]
    public string Currency { get; set; }
        [Required]
    public int QuantityAvailable { get; set; }
        [Required]
    public string DeliveryType { get; set; }
        [Required]
    public int MinDeliveryMinutes { get; set; }
        [Required]
    public int MaxDeliveryMinutes { get; set; }
}
