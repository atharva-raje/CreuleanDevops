using AutoMapper;
using BusinessLOgic.IServices;
using BusinessLOgic.Models;
using BusinessLOgic.sevices;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Controllers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/iterations")]
    [ApiController]
    public class IterationController : ControllerBase
    { 
        private readonly ILogger<IterationController> _logger;
    private readonly IIterationService iterationServices;
    private readonly IMapper _mapper;

    public IterationController(ILogger<IterationController> logger, IIterationService _iterationServices, IMapper mapper)
    {
        _logger = logger;
        iterationServices = _iterationServices;
        _mapper = mapper;
    }
    
         
        [HttpGet("{AreaId}")]
        public async Task<IActionResult> GetIterations(int AreaId)
        {
            var result = await iterationServices.GetIterations(AreaId);
            var model = _mapper.Map<IEnumerable<IterationWIthoutId>>(result);
            return Ok(model);
        }
 
    }
}
