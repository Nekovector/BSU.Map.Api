using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSU.Map.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BSU.Map.WebApi.Controllers
{
    [Route("api/structural-objects")]
    [ApiController]
    [SwaggerTag("Working with BSU structural objects")]
    public class StructuralObjectController : ControllerBase
    {
        private readonly IStructuralObjectService _structuralObjectsService;

        public StructuralObjectController(IStructuralObjectService structuralObjectsService)
        {
            _structuralObjectsService = structuralObjectsService;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllBuildings()
        {
            var bsuObjects = await _structuralObjectsService.GetBsuComplex();

            return Ok(bsuObjects);
        }
    }
}
