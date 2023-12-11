using BSU.Map.BLL.Interfaces;
using BSU.Map.BLL.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace BSU.Map.WebApi.Controllers
{

    [Route("api/scientists")]
    [ApiController]
    [SwaggerTag("Working with scientists")]
    public class ScientistController : ControllerBase
    {
        private readonly IScientistService _scentistService;

        public ScientistController (IScientistService scientistService)
        {
            _scentistService = scientistService;
        }

        [HttpGet]
        public async Task<IActionResult> GetScientist([FromQuery] int scientistId)
        {
            var scientist = await _scentistService.GetScientistInfo(scientistId);

            return Ok(scientist);
        }
    }
}
