using System.Collections.Generic;
using LIB.Contracts.RequestModel;
using LIB.Contracts.ResponseModel;

namespace LIB.Domain.Interfaces
{
    public interface IEditorRequest
    {
        public  EditorResponseModel CreateRequest(EditorCreateModel editor);
        public EditorResponseModel UpdateRequest(EditorUpdateModel editor);
        public EditorResponseModel  EditorView(int id);
        bool Clear();
        bool DeleteById(int id);
        public IEnumerable<EditorResponseModel> EditorViewMultiple();
    }
}