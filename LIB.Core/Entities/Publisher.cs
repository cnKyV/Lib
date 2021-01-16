using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIB.Core.Entities
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public ICollection<Editor> Editors { get; set; }
        public ICollection<Book> Books { get; set; }
        public Contact Contact { get; set; }
    }
}
