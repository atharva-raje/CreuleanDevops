using AutoMapper;
using BusinessLOgic.IServices;
using BusinessLOgic.Models;
using BusinessLOgic.sevices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
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

        
        [HttpGet("GetLinksForWorkItem/{workItemId}")]
        public async Task<ActionResult<List<WorkItemLinkModel>>> GetLinksForWorkItem(string workItemId)
        {
            var links = await _workItemLinkService.GetWorkItemLinksAsync(workItemId);
            if (links == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<IList<WorkItemLinkModel>>(links);
            return Ok(model);
        }

        [HttpPost("LinkWorkItems")]
        public async Task<ActionResult<bool>> LinkWorkItems([FromBody] LinkWorkItemsRequest request)
        {
            var result = await _workItemLinkService.AddWorkItemLinkAsync(request.SourceWorkItemId, request.TargetWorkItemId, request.LinkType);
            if (!result)
            {
                return BadRequest("Failed to link work items.");
            }
            return Ok(true);
        }
    

    public class LinkWorkItemsRequest
    {
        public string SourceWorkItemId { get; set; }
        public string TargetWorkItemId { get; set; }
        public int LinkType { get; set; }
    }
    [HttpDelete("link/delete/{id}")]
        public async Task<IActionResult> DeleteWorkItemLink(string id)
    {
            var result = await _workItemLinkService.DeleteWorkItemLinkAsync(id);
            
             return Ok(result);
        }
    }
}

