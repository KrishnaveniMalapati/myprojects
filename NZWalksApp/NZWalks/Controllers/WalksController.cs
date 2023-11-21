using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.Models.Domain;
using NZWalks.Models.DTOs;
using NZWalks.Repository;

namespace NZWalks.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class WalksController : ControllerBase
	{
		private readonly IMapper mapper;
		private readonly IWalkRepository walkRepository;
		public WalksController(IMapper mapper, IWalkRepository walkRepository)
        {
			this.mapper = mapper;
			this.walkRepository = walkRepository;
        }
        // create walk
        // post: /api/walks

        [HttpPost]
		public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto)
		{  
			if (ModelState.IsValid)
			{
				//map dto to domain model

				var walkDomainModel = mapper.Map<Walk>(addWalkRequestDto);

				await walkRepository.CreateAsync(walkDomainModel);

				return Ok(mapper.Map<WalkDto>(walkDomainModel));
			}

			return BadRequest(ModelState);
			
		}

		// get walks 
		// get: /api/walks
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var walksDomainModel = await walkRepository.GetAllAsync();

			// map domain model to dto

			return Ok(mapper.Map<List<WalkDto>>(walksDomainModel));
		
		}

		//get walk by id
		// GET: /api/walks/{id}

		[HttpGet]
		[Route("{id:Guid}")]

		public async Task<IActionResult> GetById([FromRoute] Guid id)
		{
			var walkDomainModel = await walkRepository.GetByIdAsync(id);
			if (walkDomainModel == null) 
			{
				return NotFound();
			}

			return Ok(mapper.Map<WalkDto>(walkDomainModel));
		}
		
		// update walk by id
		// put: /api/walks/{id}
		
		[HttpPut]
		[Route("{id:Guid}")]

		public async Task<IActionResult> Update([FromRoute] Guid id, UpdateWalkRequestDto updateWalkRequestDto)
		{
			if (ModelState.IsValid)
			{
				// map dto to domain model
				var walkDomainModel = mapper.Map<Walk>(updateWalkRequestDto);
				walkDomainModel = await walkRepository.UpdateAsync(id, walkDomainModel);

				if (walkDomainModel == null)
				{
					return NotFound();
				}
				// map domain model to dto

				return Ok(mapper.Map<WalkDto>(walkDomainModel));
			}

			return BadRequest(ModelState);
			
		}

		//delete a walk by id
		// Delete: /api/Walks/{id}
		[HttpDelete]
		[Route("{id:Guid}")]

		public async Task<IActionResult> Delete([FromRoute] Guid id)
		{
			var deleteWalkDomainModel = await walkRepository.DeleteAsync(id);

			if (deleteWalkDomainModel == null)
			{
				return NotFound();
			}

			//map domain model to dto

			return Ok(mapper.Map<WalkDto>(deleteWalkDomainModel));
		}

	}
}
