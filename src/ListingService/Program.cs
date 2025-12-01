using ListingService.Data;
using ListingService.RequestHelpers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<ListingDbContext>(opt =>
{
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddAutoMapper(cfg => { }, typeof(MappingProfiles) );


var app = builder.Build();

try
{
    DbInitializer.SeedData(app);
}
catch(Exception ex)
{
    System.Console.WriteLine(ex);
}

app.MapControllers();

app.Run();