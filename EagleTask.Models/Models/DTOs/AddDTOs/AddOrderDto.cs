
using System.ComponentModel.DataAnnotations;

namespace EagleTask.Models.Models.DTOs.AddDTOs
{
    public class AddOrderDto
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }
        public int CustomerId { get; set; }
        public string? Description { get; set; }
    }
}
