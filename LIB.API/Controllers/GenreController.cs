using LIB.Contracts.RequestModel;
using LIB.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LIB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreRequest _genreRequest;
        public GenreController(IGenreRequest genreRequest)
        {
            _genreRequest = genreRequest;
        }
        [HttpPost]
        public IActionResult Create(GenreCreateModel genreCreateModel)
        {
            return Ok(_genreRequest.CreateRequest(genreCreateModel));
        }
    }
}