using AutoMapper;
using BusinessLOgic.IServices;
using BusinessLOgic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;

namespace WebApplication1.Controllers
{
    [Route("api/priority")]
    [ApiController]
    public class PriorityController : ControllerBase
    {
        private readonly ILogger<PriorityController> _logger;
        private readonly IPriorityService _workItemServices;
        private readonly IMapper _mapper;

        public PriorityController(ILogger<PriorityController> logger, IPriorityService workItemServices, IMapper mapper)
        {
            _logger = logger;
            _workItemServices = workItemServices;
            _mapper = mapper;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetPriorites()
        {
            var result =  await _workItemServices.GetPriorities();
            var model = _mapper.Map<IEnumerable<PriorityModel>>(result);
            return Ok(model);
        }
        [HttpGet("name/{id}")]
        public async Task<IActionResult> GetPriorityName(int id)
        {
            var result = await _workItemServices.GetPriorityName(id);
            
            return Ok(result);
        }

    }
}
