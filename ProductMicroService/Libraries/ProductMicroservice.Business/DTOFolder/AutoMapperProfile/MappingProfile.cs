using AutoMapper;
using ProductMicroservice.Business.DTOFolder.RequestDTOs;
using ProductMicroservice.Business.DTOFolder.RequestDTOs.PictureDTOs;
using ProductMicroservice.Business.DTOFolder.RequestDTOs.ProductSizeDTOs;
using ProductMicroservice.Business.DTOFolder.RequestDTOs.ProductVariantDTOs;
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


            #region AddRequest DTOS
            CreateMap<AddProductDTO, ProductDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(_ => true));
            CreateMap<AddProductVariantDTO, ProductVariantDTO>()
			    .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()))
				.ForMember(dest => dest.IsActive, opt => opt.MapFrom(_ => true));
            CreateMap<AddPictureDTO, PictureDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(_ => true));
            CreateMap<AddProductSizeDTO, ProductSizeDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(_ => true));
            #endregion
        }
    }
}
