using AutoMapper;
using BusinessLOgic.IServices;
using BusinessLOgic.Models;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Controllers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/areas")]
    [ApiController]
    public class AreasController : ControllerBase
    {
        private readonly ILogger<AreasController> _logger;
        private readonly IAreaService areaServices;
        private readonly IMapper _mapper;

        public AreasController(ILogger<AreasController> logger, IAreaService _areaServices, IMapper mapper)
        {
            _logger = logger;
            areaServices = _areaServices;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAreas()
        {
            var result = await areaServices.GetAreas();
            var model = _mapper.Map<IEnumerable<AreaWithoutId>>(result);
            return Ok(model);
        }
        [HttpGet("name/{areaId}")]
        public async Task<IActionResult> GetAreaIterations(int areaId)
        {
            var result = await areaServices.GetAreaName(areaId);
            return Ok(result);
        }


    }
}
