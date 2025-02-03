using AutoMapper;
using ProductMicroservice.Business.DTOFolder;
using ProductMicroservice.Business.DTOFolder.RequestDTOs.ProductVariantPictureDTOs;
using ProductMicroservice.Data.Repositories.UnitOfWork;
using ProductMicroservice.Entities.Entities;

namespace ProductMicroservice.Business.ProductVariantPictureServiceFolder
{
    public class ProductVariantPictureService : IProductVariantPictureService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public ProductVariantPictureService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> AddProductVariantPicture(ProductVariantPictureDTO productVariantPictureDTO)
        {
            var productVariant = await _unitOfWork.ProductVariants.GetByIdAsync(productVariantPictureDTO.ProductVariantId);
            var picture = await _unitOfWork.Pictures.GetByIdAsync(productVariantPictureDTO.PictureId);

            if (productVariant != null && picture != null)
            {
                var productVariantPicture = new ProductVariantPicture()
                {
                    PictureId = productVariantPictureDTO.PictureId,
                    ProductVariantId = productVariantPictureDTO.ProductVariantId,
                    ProductVariant = productVariant,
                    Picture = picture
                };

                var result = await _unitOfWork.ProductVariantPictures.AddAsync(productVariantPicture);

                return result;
            }

            return false;
        }

        public async Task<int> BulkAddProductVariantPictures(List<AddProductVariantPictureDTO> productVariantPictures)
        {
            int failCounter = 0;
            foreach (var productVariantPictureDTO in productVariantPictures)
            {
                var productVariant = await _unitOfWork.ProductVariants.GetByIdAsync(productVariantPictureDTO.ProductVariantId);
                var picture = await _unitOfWork.Pictures.GetByIdAsync(productVariantPictureDTO.PictureId);

                if (productVariant != null && picture != null)
                {

                    var productVariantPicture = new ProductVariantPicture()
                    {
                        PictureId = productVariantPictureDTO.PictureId,
                        ProductVariantId = productVariantPictureDTO.ProductVariantId,
                        ProductVariant = productVariant,
                        Picture = picture
                    };

                    var result = await _unitOfWork.ProductVariantPictures.AddAsync(productVariantPicture);

                    if (!result)
                    {
                        failCounter++;
                    }
                }
            }

            return failCounter;
        }

        public async Task<int> BulkDeleteProductVariantPictures(List<AddProductVariantPictureDTO> productVariantPictures)
        {
            int failCounter = 0;
            foreach (var productVariantPictureDTO in productVariantPictures)
            {
                var productVariant = await _unitOfWork.ProductVariants.GetByIdAsync(productVariantPictureDTO.ProductVariantId);
                var picture = await _unitOfWork.Pictures.GetByIdAsync(productVariantPictureDTO.PictureId);

                if (productVariant != null && picture != null)
                {

                    var productVariantPicture = new ProductVariantPicture()
                    {
                        PictureId = productVariantPictureDTO.PictureId,
                        ProductVariantId = productVariantPictureDTO.ProductVariantId,
                        ProductVariant = productVariant,
                        Picture = picture
                    };

                    var result = await _unitOfWork.ProductVariantPictures.DeleteWithModelAsync(productVariantPicture);

                    if (!result)
                    {
                        failCounter++;
                    }
                }
            }

            return failCounter;
        }

        public async Task<int> DeleteProductVariantPicture(Guid productVariantId, Guid pictureId)
        {
            int failCounter = 0;

            var productVariant = await _unitOfWork.ProductVariants.GetByIdAsync(productVariantId);
            var picture = await _unitOfWork.Pictures.GetByIdAsync(pictureId);

            var mapping = await _unitOfWork.ProductVariantPictures.Query(x => x.ProductVariantId == productVariantId && x.PictureId == pictureId);

            if (productVariant != null && picture != null && mapping.Any())
            {
                foreach (var entity in mapping)
                {
                    var result = await _unitOfWork.ProductVariantPictures.DeleteWithModelAsync(entity);
                    if (!result)
                    {
                        failCounter++;
                    }
                }
            }

            return failCounter;
        }
    }
}
