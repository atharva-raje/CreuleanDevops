using AutoMapper;
using BusinessLOgic.IServices;
using BusinessLOgic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/comments")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ILogger<CommentController> _logger;
        private readonly ICommentService  commentServices;
        private readonly IMapper _mapper;

        public CommentController(ILogger<CommentController> logger, ICommentService _commentServices, IMapper mapper)
        {
            _logger = logger;
            commentServices = _commentServices;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetComments()
        {
            var results = await commentServices.GetComments();
            var model = _mapper.Map<IEnumerable<CommentModel>>(results);

            return Ok(model);
        }
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddComment([FromBody] CommentModel commentModel)
        {

            var results = await commentServices.AddComment(commentModel);
            var model = _mapper.Map<CommentModel>(results);
            return Ok(model);
        }
    }
}
