using MongoDB.Driver;
using MongoDB.Entities;
using SearchService.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

await DB.InitAsync("SearchDb", MongoClientSettings
    .FromConnectionString(builder.Configuration.GetConnectionString("MongoDbConnection")));

await DB.Index<Listing>()
    .Key(x => x.Title, KeyType.Text)
    .Key(x => x.CategoryName, KeyType.Text)
    .Key(x => x.GameName, KeyType.Text)
    .CreateAsync();


app.Run();
