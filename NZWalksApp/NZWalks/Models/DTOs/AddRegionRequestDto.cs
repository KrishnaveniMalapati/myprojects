using System.ComponentModel.DataAnnotations;

namespace NZWalks.Models.DTOs
{
    public class AddRegionRequestDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(3)]
        public string Code { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string? RegionImageUrl { get; set; }
    }
}
