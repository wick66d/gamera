using MongoDB.Driver;
using MongoDB.Entities;
using SearchService.Data;
using SearchService.Models;
using SearchService.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddHttpClient<ListingServiceHttpClient>();
var app = builder.Build();

app.MapControllers();

try
{
   await DbInitializer.InitDb(app);
}
catch(Exception e)
{
    Console.WriteLine(e);
}


app.Run();
