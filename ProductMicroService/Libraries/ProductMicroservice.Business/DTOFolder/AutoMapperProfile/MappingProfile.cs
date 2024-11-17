using AutoMapper;
using ProductMicroservice.Business.DTOFolder.RequestDTOs;
using ProductMicroservice.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.Business.DTOFolder.AutoMapperProfile
{
    public class MappingProfile : Profile
    {
        protected MappingProfile()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Picture, PictureDTO>().ReverseMap();
            CreateMap<ProductSize, ProductSizeDTO>().ReverseMap();
            CreateMap<ProductVariant, ProductVariantDTO>().ReverseMap();
            CreateMap<ProductVariantPicture, ProductVariantPictureDTO>().ReverseMap();
            CreateMap<ProductSizeRegion, ProductVariantSizeRegionDTO>().ReverseMap();
            CreateMap<AddProductDTO, ProductDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()));
        }
    }
}
