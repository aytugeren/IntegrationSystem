using AutoMapper;
using ProductMicroservice.Business.DTOFolder;
using ProductMicroservice.Business.DTOFolder.RequestDTOs.PictureDTOs;
using ProductMicroservice.Data.Repositories.UnitOfWork;
using ProductMicroservice.Entities.Entities;

namespace ProductMicroservice.Business.PictureServiceFolder
{
    public class PictureService : IPictureService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public PictureService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> AddPicture(AddPictureDTO pictureDTO)
        {
            var pictureModel = _mapper.Map<PictureDTO>(pictureDTO);
            var picture = _mapper.Map<Picture>(pictureModel);

            var result = await _unitOfWork.Pictures.AddAsync(picture);

            return result;
        }

        public async Task<bool> BulkAddPictures(List<AddPictureDTO> pictures)
        {
            var pictureModel = _mapper.Map<List<PictureDTO>>(pictures);
            var picture = _mapper.Map<List<Picture>>(pictureModel);

            var result = await _unitOfWork.Pictures.BulkAddAsync(picture);
            return result;
        }

        public async Task<bool> BulkDeletePictures(List<Guid> ids)
        {
            var pictures = await _unitOfWork.Pictures.Query(x => x.Id != null && ids.Contains(x.Id.Value));
            var deleteResult = await _unitOfWork.Pictures.BulkDeleteAsync(pictures);
            return deleteResult;
        }

        public async Task<bool> DeletePicture(Guid id)
        {
            var picture = await _unitOfWork.Pictures.GetByIdAsync(id);

            if (picture != null)
            {
                var result = await _unitOfWork.Pictures.DeleteAsync(id);

                return result;
            }

            return false;
        }

        public async Task<List<PictureDTO>> GetAllPictures()
        {
            var pictures = await _unitOfWork.Pictures.GetAllAsync();
            return _mapper.Map<List<PictureDTO>>(pictures);
        }

        public async Task<PictureDTO> GetPictureById(Guid id)
        {
            var picture = await _unitOfWork.Pictures.GetByIdAsync(id);

            return _mapper.Map<PictureDTO>(picture);
        }

        public async Task<bool> UpdatePicture(UpdatePictureDTO pictureDTO)
        {
            var picture = await _unitOfWork.Pictures.GetByIdAsync(pictureDTO.Id);

            if (picture != null )
            {
                picture.PictureUrl = pictureDTO.PictureUrl;
                picture.Width = pictureDTO.Width;
                picture.Height = pictureDTO.Height;
                picture.PictureAltName = pictureDTO.PictureAltName;
                picture.PictureName = pictureDTO.PictureName;
                picture.LogMessage = $"{DateTime.Now} tarihinde verileri güncellendi!";

                var result = await _unitOfWork.Pictures.UpdateAsync(picture);
                return result;
            }

            return false;
        }
    }
}
