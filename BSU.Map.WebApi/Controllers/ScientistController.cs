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
        public async Task<IActionResult> GetAllScientists()
        {
            var scientists = await _scientistService.GetAllScientists();
            return Ok(scientists);
        }

        [HttpGet]
        [Route("names")]
        public async Task<IActionResult> GetScientistsNames()
        {
            var scientists = await _scientistService.GetScientistsNames();
            return Ok(scientists);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetScientistById([FromRoute] int id)
        {
            var scientists = await _scientistService.GetScientistById(id);
            return Ok(scientists);
        }

        [HttpPost]
        public async Task<IActionResult> CreateScientist([FromBody] ScientistModelDto scientist)
        {
            bool result = await _scientistService.CreateScientist(scientist);
            return Ok(result);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateScientist([FromRoute] int id, [FromBody] ScientistModelDto scientist)
        {
            bool result = await _scientistService.UpdateScientist(id, scientist);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteScientist([FromRoute] int id)
        {
            bool result = await _scientistService.DeleteScientist(id);
            return Ok(result);
        }
    }
}
