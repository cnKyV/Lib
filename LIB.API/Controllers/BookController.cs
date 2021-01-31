using LIB.Contracts.RequestModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LIB.Domain.Interfaces;
using LIB.Domain.Requests;

namespace LIB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRequest _bookRequest;

        public BookController(IBookRequest bookRequest)
        {
            _bookRequest = bookRequest;
        }
        [HttpPost]
        public IActionResult Create(BookCreateModel book)
        {
            return Ok(_bookRequest.CreateRequest(book));
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_bookRequest.BookViewMultiple());
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_bookRequest.BookView(id));
        }
        [HttpPut]
        public IActionResult Update(BookUpdateModel book)
        {
            return Ok(_bookRequest.UpdateRequest(book));
        }
        [HttpDelete]
        public IActionResult Clear()
        {
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            return Ok(_bookRequest.DeleteById(id));
        }
    }
}
