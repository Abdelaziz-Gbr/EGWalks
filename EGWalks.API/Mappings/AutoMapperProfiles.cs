using AutoMapper;
using EGWalks.API.Models.Domain;
using EGWalks.API.Models.Dto;

namespace EGWalks.API.Mappings
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<RegionDto, Region>().ReverseMap();
            CreateMap<AddRegionRequestDto, Region>().ReverseMap();
            CreateMap<UpdateRegionRequestDto, Region>().ReverseMap();
        }
    }
}
