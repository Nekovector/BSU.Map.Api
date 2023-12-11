using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSU.Map.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BSU.Map.WebApi.Controllers
{
    [Route("api/photos")]
    [ApiController]
    [SwaggerTag("Working with photos")]
    public class PhotoController : ControllerBase
    {
        private readonly IPhotoService _photoService;
        private readonly IMemoryPhotoService _memoryPhotoService;

        public PhotoController(IPhotoService photoService, IMemoryPhotoService memoryPhotoService)
        {
            _photoService = photoService;
            _memoryPhotoService = memoryPhotoService;
        }

        [HttpGet]
        [Route("buildings")]
        public async Task<IActionResult> GetBuildingPhotos([FromQuery] int buildingId)
        {
            var photos = await _photoService.GetBuildingPhotos(buildingId);

            return Ok(photos);
        }

        [HttpGet]
        [Route("memoryPlaces")]
        public async Task<IActionResult> GetMemoryPhotos([FromQuery] int memoryPlaceId)
        {
            var photos = await _memoryPhotoService.GetMemoryPhotos(memoryPlaceId);

            return Ok(photos);
        }
    }
}
