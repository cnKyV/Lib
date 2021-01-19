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
        public ICollection<EditorPublisher> Editors { get; set; }
        public ICollection<BookPublisher> Books { get; set; }
        public Contact Contact { get; set; }
    }
}
