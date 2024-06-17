using AutoMapper;
using BusinessLOgic.IServices;
using BusinessLOgic.Models;
using DAL.Entites;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api")]
    public class WeatherForecastController : ControllerBase
    {
         

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWorkItemServices _workItemServices;
        private readonly IMapper _mapper;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,IWorkItemServices workItemServices,IMapper mapper)
        {
            _logger = logger;
            _workItemServices = workItemServices;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetWorkItems()
        {
            var results =  await _workItemServices.GetWorkItemsService();
            var model = _mapper.Map<IEnumerable<WorkItemModel>>(results);

            return Ok(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddWorkitem([FromBody]WorkItemModel workItemModel)
        {
           
            var results = await _workItemServices.AddWorkItemsService(workItemModel);
            var model = _mapper.Map<WorkItemModel>(results);
            return Ok(model);
        }
    }
}
