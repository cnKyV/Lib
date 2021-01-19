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
        
        public AuthorController()
        {
            
        }

        [HttpPost]
       public IActionResult Create(Author author)
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
            return Ok();
        }
        [HttpPatch]
        public IActionResult Update(Author author)
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
