using AutoMapper;
using BusinessLOgic.IServices;
using BusinessLOgic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class USerController : ControllerBase
    {
        private readonly ILogger<WorkItemController> _logger;
        private readonly IUserSerivce userServices;
        private readonly IMapper _mapper;

        public USerController(ILogger<WorkItemController> logger, IUserSerivce workItemServices, IMapper mapper)
        {
            _logger = logger;
            userServices = workItemServices;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetUSers()
        {
            var results = await userServices.GetUsers();
            var model = _mapper.Map<IEnumerable<UserModel>>(results);

            return Ok(model);
        }
    }
}
