using System;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Entities;
using SearchService.Models;

namespace SearchService.Services;

public class ListingServiceHttpClient
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _config;

    public ListingServiceHttpClient(HttpClient httpClient, IConfiguration config)
    {
        this._httpClient = httpClient;
        this._config = config;
    }

    public async Task<List<Listing>> GetListingsForSearchDb()
    {
        var lastUpdated = await DB.Find<Listing, string>()
            .Sort(x => x.Descending(x => x.UpdatedAt))
            .Project(x => x.UpdatedAt.ToString())
            .ExecuteFirstAsync();
        
        return await _httpClient.GetFromJsonAsync<List<Listing>>(_config["ListingServiceUrl"] 
        + "/api/listings?date=" + lastUpdated);
    }
}
