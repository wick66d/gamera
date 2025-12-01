using System;
using ListingService.Entities;
using ListingService.Models;
using Microsoft.EntityFrameworkCore;

namespace ListingService.Data;

public class DbInitializer
{
    public static void SeedData(WebApplication app)
    {
        using(var scope = app.Services.CreateScope())
        {
            SeedData(scope.ServiceProvider.GetService<ListingDbContext>());            
        }
    }


private static void SeedData(ListingDbContext context)
{
        if (!context.Listings.Any())
        {
                var listingsToAdd = GetSeedListings();

                context.AddRange(listingsToAdd);

                context.SaveChanges();
        }
        return;
}

private static List<Listing> GetSeedListings() => new()

    {
        new Listing
        {
            ListingId = Guid.NewGuid(),
            SellerId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
            GameId = Guid.Parse("aaaaaaa1-1111-1111-1111-111111111111"),
            GameName = "World of Warcraft",
            CategoryId = 1,
            CategoryName = "Gold",
            Title = "100k WoW Gold - Fast Delivery (EU)",
            Description = "Selling 100,000 gold on EU server. Delivery within 5-10 minutes via in-game trade.",
            PriceAmount = 15.99m,
            Currency = "USD",
            IsStackable = true,
            QuantityAvailable = 100000,
            DeliveryType = DeliveryType.InGameTrade,
            MinDeliveryMinutes = 5,
            MaxDeliveryMinutes = 10,
            Status = Status.Active
        },

        new Listing
        {
            ListingId = Guid.NewGuid(),
            SellerId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            GameId = Guid.Parse("bbbbbbb2-2222-2222-2222-222222222222"),
            GameName = "Elder Scrolls Online",
            CategoryId = 1,
            CategoryName = "Gold",
            Title = "500k ESO Gold - Cheapest Price",
            Description = "Instant delivery for 500k ESO Gold. Secure trading method.",
            PriceAmount = 18.49m,
            Currency = "USD",
            IsStackable = true,
            QuantityAvailable = 500000,
            DeliveryType = DeliveryType.InGameTrade,
            MinDeliveryMinutes = 2,
            MaxDeliveryMinutes = 15,
            Status = Status.Active
        },

        new Listing
        {
            ListingId = Guid.NewGuid(),
            SellerId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            GameId = Guid.Parse("ccccccc3-3333-3333-3333-333333333333"),
            GameName = "Fortnite",
            CategoryId = 2,
            CategoryName = "Account",
            Title = "Fortnite OG Account - Renegade Raider",
            Description = "High-tier Fortnite account with OG skins including Renegade Raider. Full access.",
            PriceAmount = 299.99m,
            Currency = "USD",
            IsStackable = false,
            QuantityAvailable = 1,
            DeliveryType = DeliveryType.AccountLogin,
            MinDeliveryMinutes = 30,
            MaxDeliveryMinutes = 120,
            Status = Status.Active
        },

        new Listing
        {
            ListingId = Guid.NewGuid(),
            SellerId = Guid.Parse("44444444-4444-4444-4444-444444444444"),
            GameId = Guid.Parse("ddddddd4-4444-4444-4444-444444444444"),
            GameName = "Lost Ark",
            CategoryId = 1,
            CategoryName = "Gold",
            Title = "1 Million Lost Ark Gold - Fast Delivery",
            Description = "Fast delivery through safe auction method. 1,000,000 gold available.",
            PriceAmount = 42.99m,
            Currency = "USD",
            IsStackable = true,
            QuantityAvailable = 1000000,
            DeliveryType = DeliveryType.InGameTrade,
            MinDeliveryMinutes = 10,
            MaxDeliveryMinutes = 20,
            Status = Status.Active
        },

        new Listing
        {
            ListingId = Guid.NewGuid(),
            SellerId = Guid.Parse("55555555-5555-5555-5555-555555555555"),
            GameId = Guid.Parse("eeeeeee5-5555-5555-5555-555555555555"),
            GameName = "League of Legends",
            CategoryId = 2,
            CategoryName = "Account",
            Title = "Diamond 2 LoL Account - 200+ Skins",
            Description = "Diamond II ranked account with rare skins and champions unlocked.",
            PriceAmount = 159.99m,
            Currency = "USD",
            IsStackable = false,
            QuantityAvailable = 1,
            DeliveryType = DeliveryType.AccountLogin,
            MinDeliveryMinutes = 20,
            MaxDeliveryMinutes = 60,
            Status = Status.Active
        },

        new Listing
        {
            ListingId = Guid.NewGuid(),
            SellerId = Guid.Parse("66666666-6666-6666-6666-666666666666"),
            GameId = Guid.Parse("fffffff6-6666-6666-6666-666666666666"),
            GameName = "CS:GO",
            CategoryId = 3,
            CategoryName = "Boosting",
            Title = "CS:GO Rank Boost - Up to Global Elite",
            Description = "Legit boosting by professional players. Safe, VPN protected.",
            PriceAmount = 49.99m,
            Currency = "USD",
            IsStackable = false,
            QuantityAvailable = 1,
            DeliveryType = DeliveryType.Other,
            MinDeliveryMinutes = 60,
            MaxDeliveryMinutes = 240,
            Status = Status.Active
        },

        new Listing
        {
            ListingId = Guid.NewGuid(),
            SellerId = Guid.Parse("77777777-7777-7777-7777-777777777777"),
            GameId = Guid.Parse("aaaaaaa2-7777-7777-7777-777777777777"),
            GameName = "RuneScape 3",
            CategoryId = 1,
            CategoryName = "Gold",
            Title = "RS3 Gold - 50M Fast Delivery",
            Description = "Selling 50 million RS3 gold. Instant delivery most of the time.",
            PriceAmount = 12.49m,
            Currency = "USD",
            IsStackable = true,
            QuantityAvailable = 50000000,
            DeliveryType = DeliveryType.InGameTrade,
            MinDeliveryMinutes = 1,
            MaxDeliveryMinutes = 10,
            Status = Status.Active
        },

        new Listing
        {
            ListingId = Guid.NewGuid(),
            SellerId = Guid.Parse("88888888-8888-8888-8888-888888888888"),
            GameId = Guid.Parse("bbbbbbb8-8888-8888-8888-888888888888"),
            GameName = "Genshin Impact",
            CategoryId = 2,
            CategoryName = "Account",
            Title = "Genshin AR55 Account - Multiple 5★ Characters",
            Description = "Endgame-ready Genshin Impact account with many constellations and strong gear.",
            PriceAmount = 89.00m,
            Currency = "USD",
            IsStackable = false,
            QuantityAvailable = 1,
            DeliveryType = DeliveryType.AccountLogin,
            MinDeliveryMinutes = 30,
            MaxDeliveryMinutes = 90,
            Status = Status.Active
        },

        new Listing
        {
            ListingId = Guid.NewGuid(),
            SellerId = Guid.Parse("99999999-9999-9999-9999-999999999999"),
            GameId = Guid.Parse("ccccccc9-9999-9999-9999-999999999999"),
            GameName = "Diablo 4",
            CategoryId = 3,
            CategoryName = "Boosting",
            Title = "Diablo 4 Powerleveling 1-100",
            Description = "Fast and safe Diablo 4 powerleveling service up to level 100.",
            PriceAmount = 59.99m,
            Currency = "USD",
            IsStackable = false,
            QuantityAvailable = 1,
            DeliveryType = DeliveryType.Other,
            MinDeliveryMinutes = 20,
            MaxDeliveryMinutes = 360,
            Status = Status.Active
        },

        new Listing
        {
            ListingId = Guid.NewGuid(),
            SellerId = Guid.Parse("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee"),
            GameId = Guid.Parse("ddddddd0-0000-0000-0000-000000000000"),
            GameName = "Path of Exile",
            CategoryId = 1,
            CategoryName = "Currency",
            Title = "Exalted Orbs - 50x (Softcore League)",
            Description = "Selling 50 Exalted Orbs. Delivered via trade in hideout.",
            PriceAmount = 23.75m,
            Currency = "USD",
            IsStackable = true,
            QuantityAvailable = 50,
            DeliveryType = DeliveryType.InGameTrade,
            MinDeliveryMinutes = 5,
            MaxDeliveryMinutes = 15,
            Status = Status.Active
        }

};
}