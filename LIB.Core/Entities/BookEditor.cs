using System;
using System.Collections.Generic;
using System.Text;

namespace LIB.Core.Entities
{
    public class BookEditor
    {
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int EditorId { get; set; }
        public Editor Editor { get; set; }
    }


}
