using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.Business.DTOFolder;
using ProductMicroservice.Business.DTOFolder.RequestDTOs.PictureDTOs;
using ProductMicroservice.Business.PictureServiceFolder;

namespace ProductMicroservice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PictureController : ControllerBase
    {
        private readonly IPictureService _pictureService;

        public PictureController(IPictureService pictureService)
        {
            _pictureService = pictureService;
        }

        [HttpPost("AddPicture")]
        public async Task<bool> AddPicture(AddPictureDTO model)
        {
            var result = await _pictureService.AddPicture(model);
            return result;
        }

        [HttpGet("GetAllPictures")]
        public async Task<List<PictureDTO>> GetAllPictures()
        {
            var result = await _pictureService.GetAllPictures();
            return result;
        }

        [HttpDelete("DeletePicture")]
        public async Task<bool> DeletePicture(Guid id)
        {
            var result = await _pictureService.DeletePicture(id);
            return result;
        }

        [HttpPost("BulkAddPictures")]
        public async Task<bool> BulkAddPictures(List<AddPictureDTO> pictures)
        {
            var result = await _pictureService.BulkAddPictures(pictures);
            return result;
        }

        [HttpDelete("BulkDeletePictures")]
        public async Task<bool> BulkDeletePictures(List<Guid> ids)
        {
            var result = await _pictureService.BulkDeletePictures(ids);
            return result;
        }

        [HttpPut("UpdatePicture")]
        public async Task<bool> UpdatePicture(UpdatePictureDTO model)
        {
            var result = await _pictureService.UpdatePicture(model);
            return result;
        }


    }
}
