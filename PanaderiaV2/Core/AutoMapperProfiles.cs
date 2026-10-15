using AutoMapper;
using PanaderiaV2.Web.Data.Entities;
using PanaderiaV2.Web.DTOs;
using PanaderiaV2.Web.DTOs.Product;


namespace PanaderiaV2.Web.Core
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Product, ProductDTO>().ForMember(dto => dto.Name, entity => entity.MapFrom(s => s.Name))
                                            .ReverseMap();

            CreateMap<Product, CreateProductDTO>().ReverseMap();

            CreateMap<Product, UpdateProductDTO>().ReverseMap();
        }
    }
}
