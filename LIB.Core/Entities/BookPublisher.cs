using System;
using System.Collections.Generic;
using System.Text;

namespace LIB.Core.Entities
{
    public class BookPublisher
    {
        public int Id { get; set; }
        public Book Book { get; set; }
        public Publisher Publisher { get; set; }
    }
}
