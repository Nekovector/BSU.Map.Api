using System.Threading.Tasks;
using BSU.Map.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BSU.Map.WebApi.Controllers
{
    [Route("api/buildings")]
    [ApiController]
    [SwaggerTag("Working with buildings")]
    public class BuildingController : ControllerBase
    {
        private readonly IBuildingService _buildingService;

        public BuildingController(IBuildingService buildingService)
        {
            _buildingService = buildingService;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllBuildings()
        {
            var buildings = await _buildingService.GetAllBuildingsInfoAsync();

            return Ok(buildings);
        }

        [HttpGet]
        [Route("modern")]
        public async Task<IActionResult> GetModernBuildings()
        {
            var buildings = await _buildingService.GetModernBuildingsInfoAsync();

            return Ok(buildings);
        }

        [HttpGet]
        [Route("historical")]
        public async Task<IActionResult> GetHistoricalBuildings()
        {
            var buildings = await _buildingService.GetHistoricalBuildingsInfoAsync();

            return Ok(buildings);
        }
    }
}
