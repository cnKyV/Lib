using LIB.Contracts.RequestModel;
using LIB.Domain.Interfaces;
using LIB.Domain.Requests;
using Microsoft.AspNetCore.Mvc;

namespace LIB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherRequest _publisherRequest;

        public PublisherController(IPublisherRequest publisherRequest)
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

        [HttpPost]
        public IActionResult Create(PublisherCreateModel createModel)
        {
            return Ok(_publisherRequest.Create(createModel));
        }

        [HttpPut]
        public IActionResult Update(PublisherUpdateModel updateModel)
        {
            return Ok(_publisherRequest.Update(updateModel));
        }
    }
}