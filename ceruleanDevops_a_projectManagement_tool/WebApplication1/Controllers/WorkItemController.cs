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
    public class WorkItemController : ControllerBase
    {
         

        private readonly ILogger<WorkItemController> _logger;
        private readonly IWorkItemServices _workItemServices;
        private readonly IMapper _mapper;

        public WorkItemController(ILogger<WorkItemController> logger,IWorkItemServices workItemServices,IMapper mapper)
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
        [HttpGet]
        [Route("getById")]
        public async Task<IActionResult> GetWorkItemsWithId()
        {
            var results = await _workItemServices.GetWorkItemsService();
            var model = _mapper.Map<IEnumerable<WorkItemModelWIthId>>(results);

            return Ok(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddWorkitem([FromBody]WorkItemModel workItemModel)
        {
           
            var results = await _workItemServices.AddWorkItemsService(workItemModel);
            var model = _mapper.Map<WorkItemModel>(results);
            return Ok(model);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateWorkItem(int id,[FromBody]WorkItemModel workItemModel)
        {
            var results = await _workItemServices.UpdateWorkItemsService(id,workItemModel);
            var model = _mapper.Map<WorkItemModel>(results);
            return Ok(model);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteWorkItem(int WorkItemId)
        {
            var results = await _workItemServices.DeleteWorkItemsService(WorkItemId);
            if(results == 1)
            {
                return Ok("delete successfull");
            }
            else
            {
                return NotFound("element not found or error occured in the server try again");
            }
             
        }
    }
}
