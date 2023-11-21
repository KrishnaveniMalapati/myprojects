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
            CreateMap<AddWalkRequestDto, Walk>().ReverseMap();
            CreateMap<Walk, WalkDto>().ReverseMap();
            CreateMap<Difficulty, DifficultyDto>().ReverseMap();    
            CreateMap<UpdateWalkRequestDto, Walk>().ReverseMap();
        }
    }
}
