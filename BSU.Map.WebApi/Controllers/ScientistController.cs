using BSU.Map.BLL.Dtos.ScientistDtos;
using BSU.Map.BLL.Interfaces;

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
        private readonly IScientistService _scientistService;

        
        public ScientistController (IScientistService scientistService)
        {
            _scientistService = scientistService;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllScientists()
        {
            var scientists = await _scientistService.GetAllScientists();
            return Ok(scientists);
        }

        [HttpGet]
        [Route("all/names")]
        public async Task<IActionResult> GetScientistsNames()
        {
            var scientists = await _scientistService.GetScientistsNames();
            return Ok(scientists);
        }

        [HttpGet]
        [Route("{id}")]
        public  IActionResult GetScientistById([FromRoute] int scientistId)
        {
            var scientists = _scientistService.GetScientistById(scientistId);
            return Ok(scientists);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateScientist([FromBody] ScientistModelDto scientist)
        {
            bool result = await _scientistService.CreateScientist(scientist);
            return Ok(result);
        }

        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> UpdateScientist([FromRoute] int scientistId, [FromBody] ScientistModelDto scientist)
        {
            bool result = await _scientistService.UpdateScientist(scientistId, scientist);
            return Ok(result);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> UpdateScientist([FromRoute] int scientistId)
        {
            bool result = await _scientistService.DeleteScientist(scientistId);
            return Ok(result);
        }
    }
}
