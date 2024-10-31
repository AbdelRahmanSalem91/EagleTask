
namespace EagleTask.Models.Models.Domains
{
    public class Order
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public ICollection<Product> Products { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public List<ProductsOrders> ProductsOrders { get; set; }
    }
}
