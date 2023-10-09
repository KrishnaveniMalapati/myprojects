using AutoMapper;
using NZWalks.Models.Domain;
using NZWalks.Models.DTOs;

namespace NZWalks.Mappings
{
    public class AutoMapperProfiles : Profile 
    {
        public AutoMapperProfiles()
        {
            CreateMap<Region, RegionDtos>().ReverseMap();
            CreateMap<AddRegionRequestDto, Region>().ReverseMap();
            CreateMap<UpdateRegionRequesDto, Region>().ReverseMap();
        }
    }
}
