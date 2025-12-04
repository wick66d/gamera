using System;
using System.Text.Json;
using Microsoft.VisualBasic;
using MongoDB.Driver;
using MongoDB.Entities;
using SearchService.Models;
using SearchService.Services;

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

        using var scope = app.Services.CreateScope();

        var httpClient = scope.ServiceProvider.GetRequiredService<ListingServiceHttpClient>();

        var listings = await httpClient.GetListingsForSearchDb();

        Console.WriteLine(listings.Count + " returned from the listing service");

        if(listings.Count > 0) await DB.SaveAsync(listings);
    }
    
}
