using AutoMapper;
using BusinessLOgic.IServices;
using BusinessLOgic.Models;
using DAL.Entites;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using WebAPplication.UI.UiModels;

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
        [Route("getall")]
        public async Task<IActionResult> GetWorkItems()
        {
            var results =  await _workItemServices.GetWorkItemsService();
            var model = _mapper.Map<IEnumerable<WorkItemModel>>(results);

            return Ok(model);
        }
        [HttpGet]
        [Route("getallWithName")]
        public async Task<IActionResult> GetWorkItemsWithName()
        {
            var results = await _workItemServices.GetWorkItemsWithNames();
            return Ok(results);
        }
        [HttpGet]
        [Route("getById/{workItemId}")]
        public async Task<IActionResult> GetWorkItemsWithId(string workItemId)
        {
            var results = await _workItemServices.GetWorkItemById(workItemId);
            var model = _mapper.Map<WorkItemModel>(results);

            return Ok(model);
        }
        [HttpGet]
        [Route("generateKey")]
        public async Task<string> GenerateKey(UIWorkItem workItem)  
        {
            var result = await _workItemServices.GenerateUniqueKeyAsync(workItem);
            return result;
        }
        [HttpGet("key/{uniqueKey}")]
  

        [HttpPost]
        public async Task<IActionResult> AddWorkitem([FromBody]UIWorkItem workItemModel)
        {
            
            var results = await _workItemServices.AddWorkItemsService(workItemModel);
            var model = _mapper.Map<WorkItemModel>(results);
            return Ok(model);
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateWorkItem([FromBody]UIWorkItem workItemModel)
        {
            var results = await _workItemServices.UpdateWorkItemsService(workItemModel);
            var model = _mapper.Map<WorkItemModel>(results);
            return Ok(model);
        }
        [HttpPut("update/name")]
        public async Task<IActionResult> UpdateWorkItemWithNames([FromBody] WorkItemModelWithString workItemModel)
        {
            var results = await _workItemServices.UpdateWorkItemsServiceWithNames(workItemModel);
            var model = _mapper.Map<WorkItemModel>(results);
            return Ok(model);
        }

        [HttpDelete]
        [Route("delete/{WorkItemId}")]
        public async Task<IActionResult> DeleteWorkItem(string WorkItemId)
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
