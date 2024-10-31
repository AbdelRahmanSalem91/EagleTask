
using EagleTask.Models.Models.Domains;
using System.ComponentModel.DataAnnotations;

namespace EagleTask.Models.Models.DTOs.AddDTOs
{
    public class AddProductDto
    {
        [Required]
        [MaxLength(200, ErrorMessage = "Title can not be more than 200 letters!")]
        public string Title { get; set; }

        [MaxLength(200, ErrorMessage = "Description can not be more than 200 letters!")]
        public string? Description { get; set; }

        [Required]
        public int BrandId { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
    }
}
