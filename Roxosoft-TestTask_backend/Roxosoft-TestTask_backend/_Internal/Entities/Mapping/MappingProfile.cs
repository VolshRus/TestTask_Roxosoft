using AutoMapper;

using System.Linq;

using WebApp.Models;
using WebApp.Responses;

namespace WebApp._Internal.Entities.Mapping
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductEntity, Product>();

            CreateMap<OrderEntity, Order>()
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.OrderProducts.Select(op => op.Product)));

            CreateMap<Order, OrderResponse>();
        }
    }
}
