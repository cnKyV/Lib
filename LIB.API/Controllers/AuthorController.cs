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
        private readonly IAuthorRepository _authorRepository;
        public AuthorController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        [HttpPost]
       public IActionResult Create(Author author)
        {
            return Ok(_authorRepository.Create(author));
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_authorRepository.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_authorRepository.GetById(id));
        }
        [HttpPatch]
        public IActionResult Update(Author author)
        {
            return Ok(_authorRepository.Update(author));
        }
        [HttpDelete]
        public IActionResult Clear()
        {
            return Ok(_authorRepository.Clear());
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            return Ok(_authorRepository.DeleteById(id));
        }

    }
}
