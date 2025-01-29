using ProductMicroservice.Business.DTOFolder;
using ProductMicroservice.Business.DTOFolder.RequestDTOs.PictureDTOs;

namespace ProductMicroservice.Business.PictureServiceFolder
{
    public interface IPictureService
    {
        Task<List<PictureDTO>> GetAllPictures();

        Task<PictureDTO> GetPictureById(Guid id);

        Task<bool> AddPicture(AddPictureDTO pictureDTO);

        Task<bool> DeletePicture(Guid id);

        Task<bool> UpdatePicture(UpdatePictureDTO pictureDTO);

        Task<bool> BulkAddPictures(List<AddPictureDTO> pictures);

        Task<bool> BulkDeletePictures(List<Guid> ids);
    }
}
