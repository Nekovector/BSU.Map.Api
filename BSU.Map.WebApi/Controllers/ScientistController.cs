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
        [Route("all")]
        public async Task<IActionResult> GetAllScientists()
        {
            var scientists = await _scentistService.GetAllScientists();

            return Ok(scientists);
        }
    }
}
