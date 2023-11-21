﻿using NZWalks.Models.Domain;

namespace NZWalks.Repository
{
	public interface IWalkRepository
	{
		Task<Walk> CreateAsync(Walk walk);

		Task<List<Walk>> GetAllAsync();

		Task<Walk?> GetByIdAsync(Guid id);

		Task<Walk?> UpdateAsync(Guid id,Walk walk);
		Task<Walk?> DeleteAsync(Guid id);	
	}
}
