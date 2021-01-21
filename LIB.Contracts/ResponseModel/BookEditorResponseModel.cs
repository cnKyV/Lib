using System;
using System.Collections.Generic;
using System.Text;

namespace LIB.Contracts.ResponseModel
{
    public class BookEditorResponseModel
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int EditorId { get; set; }
    }
}
