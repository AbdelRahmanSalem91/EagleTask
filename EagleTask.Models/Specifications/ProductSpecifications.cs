using EagleTask.Models.Models.Domains;

namespace EagleTask.Models.Specifications
{
    public class ProductSpecifications : Specification<Product>
    {
        public ProductSpecifications()
        {
            AddIncludes(p => p.Category);
            AddIncludes(p => p.Brand);
        }
    }
}
