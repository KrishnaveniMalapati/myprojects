using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.Data;
using NZWalks.Models.Domain;
using NZWalks.Models.DTOs;
using NZWalks.Repository;
using System.Net.WebSockets;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace NZWalks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext dbContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(NZWalksDbContext dbContext, IRegionRepository regionRepository,
           IMapper mapper )
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }
        // GET ALL regions
        [HttpGet]
        public  async Task<IActionResult> GetAll()
        {
            // gat data from databse - domain models
            var regionsDomain = await regionRepository.GetAllAsync();
            // map doamain models to DTOs
            //var regionsDto = new List<RegionDtos>();
            //foreach (var regionDomain in regionsDomain)
            //{
            //    regionsDto.Add(new RegionDtos()
            //    {
            //        Id = regionDomain.Id,
            //        Code = regionDomain.Code,
            //        Name = regionDomain.Name,
            //        RegionImageUrl = regionDomain.RegionImageUrl
            //    });
            //}

            // other method called automapper.

            //map domain models  to dto
            var regionsDto = mapper.Map<List<RegionDtos>>(regionsDomain);
            // return DTOs
            return Ok(regionsDto);
        }

        // GET single region (get region by Id)
        [HttpGet]
        [Route("{id:Guid}")]

        public IActionResult GetById([FromRoute] Guid id)
        {
            // var region = dbContext.Regions.Find(id);
            // get region domain model from database
            var regionDomain =  regionRepository.GetByIdAsync(id);
            if (regionDomain == null)
            {
                return NotFound();
            }

            //convert region domain model to region dtos return dtos back to client
                                  
            
            return Ok(mapper.Map<RegionDtos>(regionDomain));
        }

        //post to create new region 
        [HttpPost]
       
        public async Task<IActionResult>Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            // map or convert dto to domain model
            var regionDomainModel = mapper.Map<Region>(addRegionRequestDto);

            // use  domain model to create region
            regionDomainModel = await regionRepository.CreateAsync(regionDomainModel);

            //map domain model back to dto
            var regionDto = mapper.Map<RegionDtos>(regionDomainModel);

            return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);
        }

        //update region 
        [HttpPut]
        [Route("{id:Guid}")]

        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequesDto updateRegionRequesDto )
        {
            //check if region exists

            var regionDomainModel = mapper.Map<Region>(updateRegionRequesDto);

            regionDomainModel = await regionRepository.UpdateAsync(id, regionDomainModel);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            // convert domain model to dto
                    
            return Ok(mapper.Map<RegionDtos>(regionDomainModel));
        }

        //Delete region
        [HttpDelete]
        [Route("{id:Guid}")]

        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionDomainModel =  await regionRepository.DeleteAsync(id);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<RegionDtos>(regionDomainModel));
        }


    }
}
