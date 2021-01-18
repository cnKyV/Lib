using System;
using System.Collections.Generic;
using System.Text;

namespace LIB.Core.Entities
{
    public class BookLibrary
    {
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int LibraryId { get; set; }
        public Library Library { get; set; }
    }
}
