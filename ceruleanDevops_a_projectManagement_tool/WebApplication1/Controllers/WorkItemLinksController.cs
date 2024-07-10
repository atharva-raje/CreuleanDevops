using AutoMapper;
using BusinessLOgic.IServices;
using BusinessLOgic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Extensions.Logging;

namespace WebApplication1.Controllers
{

    [Route("api")]
    [ApiController]
    public class WorkItemLinksController : ControllerBase
    {
        private readonly IWorkItemLinkService _workItemLinkService;
        private readonly ILogger<WorkItemLinksController> _logger;
        private readonly IMapper _mapper;

        public WorkItemLinksController(ILogger<WorkItemLinksController> logger,IWorkItemLinkService workItemService, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _workItemLinkService = workItemService;
        }

        [HttpPost("link")]
        public async Task<IActionResult> AddWorkItemLink([FromBody]WorkItemLinkModel workItemLinkModel)
        {
             var result  = await _workItemLinkService.AddWorkItemLinkAsync(workItemLinkModel.sourceWorkItemId, workItemLinkModel.targetWorkItemId, workItemLinkModel.linkType);
            if(result == 1)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}/links")]
        public async Task<IActionResult> GetWorkItemLinks(string id)
        {
            var workItemLinks = await _workItemLinkService.GetWorkItemLinksAsync(id);
            var model = _mapper.Map<List<WorkItemLinkModel>>(workItemLinks);
            return Ok(model);
        }
        [HttpDelete("link/delete/{id}")]
        public async Task<IActionResult> DeleteWorkItemLink(string id)
        {
            var result = await _workItemLinkService.DeleteWorkItemLinkAsync(id);
            
             return Ok(result);
        }
    }
}
