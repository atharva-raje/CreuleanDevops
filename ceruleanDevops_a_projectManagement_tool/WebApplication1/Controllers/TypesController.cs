using AutoMapper;
using BusinessLOgic.IServices;
using BusinessLOgic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Controllers;

namespace WebApplication1.Controllers
{
    [Route("api/types")]
    [ApiController]
    public class TypesController : ControllerBase
    {

        private readonly ILogger<TypesController> _logger;
        private readonly ITypeService _TypeService;
        private readonly IMapper _mapper;

        public TypesController(ILogger<TypesController> logger, ITypeService TypeService, IMapper mapper)
        {
            _logger = logger;
            _TypeService = TypeService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult>  GetTypes()
        {
            var results = await _TypeService.GetTypes();
            var model = _mapper.Map<IEnumerable<TypeModel>>(results);
            return Ok(model);
        }
        [HttpGet]
        [Route("name/{id}")]
        public async Task<IActionResult> GetTypeName(int id)
        {
            var results = await _TypeService.GetTypeName(id);
 
            return Ok(results);
        }
    }
}
