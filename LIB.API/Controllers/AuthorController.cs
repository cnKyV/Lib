using AutoMapper;
using LIB.Contracts.RequestModel;
using LIB.Contracts.ResponseModel;
using LIB.Domain.Interfaces;
using LIB.Domain.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRequest _authorRequest;

        public AuthorController(IAuthorRequest authorRequest)
        {
            _authorRequest = authorRequest;
        }

        [HttpPost]
       public IActionResult Create(AuthorCreateModel author)
        {

            return Ok(_authorRequest.CreateRequest(author));
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_authorRequest.AuthourViewMultiple());
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_authorRequest.AuthorView(id));
        }
        [HttpPut]
        public IActionResult Update(AuthorUpdateModel author)
        {
            return Ok(_authorRequest.UpdateRequest(author));
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            return Ok(_authorRequest.DeleteById(id));
        }

    }
}
