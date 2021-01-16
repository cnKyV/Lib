using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIB.Core.Entities
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string About { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public ICollection<Book> Books { get; set; }
        public Contact Address { get; set; }
    }
}
