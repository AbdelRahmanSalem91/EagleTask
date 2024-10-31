using EagleTask.Models.Models.Domains;
using System.Text.Json;

namespace EagleTask.Data
{
    public class DataSeedContext
    {
        public static async Task SeedDataAsync(OrderManagementDbContext context)
        {
            if (!context.Brands.Any())
            {
                var brandsData = File.ReadAllText("../EagleTask.Data/DataSeed/brands.json");
                var brands = JsonSerializer.Deserialize<List<Brand>>(brandsData);
                context.Brands.AddRange(brands);
            }

            if (!context.Categories.Any())
            {
                var categoriesData = File.ReadAllText("../EagleTask.Data/DataSeed/categories.json");
                var categories = JsonSerializer.Deserialize<List<Category>>(categoriesData);
                context.Categories.AddRange(categories);
            }

            if (!context.Products.Any())
            {
                var productsData = File.ReadAllText("../EagleTask.Data/DataSeed/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                context.Products.AddRange(products);
            }

            if (!context.Customers.Any())
            {
                var customersData = File.ReadAllText("../EagleTask.Data/DataSeed/customers.json");
                var customers = JsonSerializer.Deserialize<List<Customer>>(customersData);
                context.Customers.AddRange(customers);
            }

            if (!context.Roles.Any())
            {
                var rolesData = File.ReadAllText("../EagleTask.Data/DataSeed/roles.json");
                var roles = JsonSerializer.Deserialize<List<Role>>(rolesData);
                context.Roles.AddRange(roles);
            }

            if (!context.Users.Any())
            {
                var usersData = File.ReadAllText("../EagleTask.Data/DataSeed/users.json");
                var users = JsonSerializer.Deserialize<List<User>>(usersData);
                context.Users.AddRange(users);
            }

            if (context.ChangeTracker.HasChanges()) 
                await context.SaveChangesAsync();
        }
    }
}
