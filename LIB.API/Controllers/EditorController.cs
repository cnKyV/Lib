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

        [HttpPut]
        public IActionResult Update(EditorUpdateModel editorUpdateModel)
        {
            return Ok(_editorRequest.UpdateRequest(editorUpdateModel));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            return Ok(_editorRequest.DeleteById(id));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_editorRequest.EditorViewMultiple());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_editorRequest.EditorView(id));
        }
    }
}