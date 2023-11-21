using System.ComponentModel.DataAnnotations;

namespace NZWalks.Models.DTOs
{
    public class UpdateRegionRequesDto
    {
        [Required]
        [MinLength(3, ErrorMessage ="Code has to be a min 3 char")]
        [MaxLength(3, ErrorMessage ="Code  has to be a max 3 char")]
        public string Code { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage =" Name has to be a max of 100 char's")]
        public string Name { get; set; }

        public string? RegionImageUrl { get; set; }
    }
}
