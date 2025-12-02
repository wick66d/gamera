using System;
using System.Text.Json;
using Microsoft.VisualBasic;
using MongoDB.Driver;
using MongoDB.Entities;
using SearchService.Models;

namespace SearchService.Data;

public class DbInitializer
{
    public static async Task InitDb(WebApplication app)
    {
        await DB.InitAsync("SearchDb", MongoClientSettings
            .FromConnectionString(app.Configuration.GetConnectionString("MongoDbConnection")));

        await DB.Index<Listing>()
            .Key(x => x.Title, KeyType.Text)
            .Key(x => x.Description, KeyType.Text)
            .Key(x => x.CategoryName, KeyType.Text)
            .Key(x => x.GameName, KeyType.Text)
            .CreateAsync();
        var count = await DB.CountAsync<Listing>();

        if(count == 0)
        {
            System.Console.WriteLine("No data - will attempt to seed");
            var listingData = await File.ReadAllTextAsync("Data/listings.json");

            var options = new JsonSerializerOptions{PropertyNameCaseInsensitive = true};

            var listings = JsonSerializer.Deserialize<List<Listing>>(listingData, options);

            await DB.SaveAsync(listings);
        }
    }
    
}
