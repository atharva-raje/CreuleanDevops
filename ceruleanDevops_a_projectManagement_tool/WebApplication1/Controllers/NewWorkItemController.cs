using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewWorkItemController : ControllerBase
    {
        // GET: api/<NewWorkItemController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<NewWorkItemController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<NewWorkItemController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<NewWorkItemController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<NewWorkItemController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
