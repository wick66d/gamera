using ListingService.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ListingDbContext>(opt =>
{
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

try
{
    DbInitializer.SeedData(app);
}
catch(Exception ex)
{
    System.Console.WriteLine(ex);
}

app.Run();