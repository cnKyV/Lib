using LIB.Domain.Requests;
using Microsoft.AspNetCore.Mvc;

namespace LIB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly PublisherRequest _publisherRequest;

        public PublisherController(PublisherRequest publisherRequest)
        {
            _publisherRequest = publisherRequest;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_publisherRequest.View());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_publisherRequest.View(id));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            return Ok(_publisherRequest.DeleteById(id));
        }
    }
}