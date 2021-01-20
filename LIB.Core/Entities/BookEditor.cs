using System;
using System.Collections.Generic;
using System.Text;

namespace LIB.Core.Entities
{
    public class BookEditor
    {
        public int Id { get; set; }
        public Book Book { get; set; }
        public Editor Editor { get; set; }
    }


}
