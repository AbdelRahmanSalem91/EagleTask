
namespace EagleTask.Models.Models.Domains
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public decimal Price { get; set; }
        public ICollection<Order> Orders { get; set; }
        public List<ProductsOrders> ProductsOrders { get; set; }
    }
}
