using System;

namespace ListingService.Entities;

public enum DeliveryType : byte
{
    InGameTrade = 0,
    AccountLogin = 1,
    CodeOrKey = 2,
    Other = 3
}
