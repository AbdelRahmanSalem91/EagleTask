using AutoMapper;
using EagleTask.Models.Models.Domains;
using EagleTask.Models.Models.DTOs;
using EagleTask.Models.Models.DTOs.AddDTOs;

namespace EagleTask.API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // Customer Mappings
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<AddCustomerDto, Customer>().ReverseMap();

            // Product Mappings
            CreateMap<Product, ProductDto>()
                .ForMember(d => d.Category, o => o.MapFrom(s => s.Category.Title))
                .ForMember(d => d.Brand, o => o.MapFrom(s => s.Brand.Title))
                .ReverseMap();
            CreateMap<AddProductDto, Product>().ReverseMap();

            // Order Mappings
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<AddOrderDto, Order>().ReverseMap();

            // User Mappings
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<AddOrderDto, Order>().ReverseMap();
        }
    }
}
