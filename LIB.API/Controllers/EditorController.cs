using LIB.Contracts.RequestModel;
using LIB.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LIB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditorController : ControllerBase
    {
        private readonly IEditorRequest _editorRequest;

        public EditorController(IEditorRequest editorRequest)
        {
            _editorRequest = editorRequest;
        }

        [HttpPost]
        public IActionResult Create(EditorCreateModel editorCreateModel)
        {
            return Ok(_editorRequest.CreateRequest(editorCreateModel));
        }
    }
}