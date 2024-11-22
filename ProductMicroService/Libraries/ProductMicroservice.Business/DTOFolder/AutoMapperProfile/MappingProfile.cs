using AutoMapper;
using ProductMicroservice.Business.DTOFolder.RequestDTOs;
using ProductMicroservice.Entities.Entities;

namespace ProductMicroservice.Business.DTOFolder.AutoMapperProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
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
