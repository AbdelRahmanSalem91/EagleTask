
using EagleTask.Models.Models.Domains;

namespace EagleTask.Models.Models.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public int CustomerId { get; set; }
    }
}
