using System;
using AutoMapper;
using ListingService.DTOs;
using ListingService.Entities;

namespace ListingService.RequestHelpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Listing, ListingDTO>();
        CreateMap<CreateListingDTO, Listing>();
    }
}
