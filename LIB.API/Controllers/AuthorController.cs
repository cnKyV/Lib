using AutoMapper;
using LIB.Contracts.RequestModel;
using LIB.Contracts.ResponseModel;
using LIB.Core.Entities;
using LIB.Infrastructure.Interfaces;
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
        private readonly IMapper _mapper;
        private readonly IAuthorService _authorService;
        private readonly IBookService _bookService;
        public AuthorController(IMapper mapper, IAuthorService authorService, IBookService bookService)
        {
            _mapper = mapper;
            _authorService = authorService;
            _bookService = bookService;
        }

        [HttpPost]
       public IActionResult Create(AuthorCreateModel author)
        {

            return Ok();
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_authorService.GetById(id));
        }
        [HttpPatch]
        public IActionResult Update(AuthorUpdateModel author)
        {
            return Ok();
        }
        [HttpDelete]
        public IActionResult Clear()
        {
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            return Ok();
        }

    }
}
