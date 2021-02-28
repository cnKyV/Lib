using AutoMapper;
using LIB.Contracts.RequestModel;
using LIB.Contracts.ResponseModel;
using LIB.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LIB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactRequest _contactRequest;
        public ContactController(IContactRequest contactRequest, IMapper mapper)
        {
            _contactRequest = contactRequest;
        }

        [HttpPut]
        public IActionResult Update(ContactUpdateModel contactUpdateModel)
        {
            return Ok(_contactRequest.Update(contactUpdateModel));
        }
    }
}