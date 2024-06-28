using AutoMapper;
using BusinessLOgic.IServices;
using BusinessLOgic.Models;
using DAL.Entites;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Reflection.Metadata.Ecma335;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{

    [ApiController]
    [Route("api/status")]
    public class StatusController : ControllerBase
    {
        private readonly ILogger<StatusController> _logger;
        private readonly IStatusService  statusService;
        private readonly IMapper _mapper;

        public StatusController(ILogger<StatusController> logger, IStatusService _statusService, IMapper mapper)
        {
            _logger = logger;
            statusService = _statusService;
            _mapper = mapper;
        }


        // GET api/<StatusController>/5
        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetStatusId(string name)
        {
           var result = await statusService.GetStatusId(name);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetStatuses()
        {
            var result = await statusService.GetStatuses();

            var model = _mapper.Map<IEnumerable<StatusModelWithoutId>>(result);
            return Ok(model);
        }
        [HttpGet("id/{statusId}")]
        public async Task<IActionResult> GetStatusName(int statusId)
        {
            var result = await statusService.GetStatusName(statusId);
            return Ok(result);
        }
    }
}
