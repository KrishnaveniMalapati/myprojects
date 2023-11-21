﻿namespace NZWalks.Models.DTOs
{
	public class WalkDto
	{
		public Guid Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public double LengthInKm { get; set; }

		public string? WalkImageUrl { get; set; }

	
		public RegionDtos Region { get; set; }
		public DifficultyDto Difficulty { get; set; }

	}
}
