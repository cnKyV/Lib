using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LIB.Core.Entities
{
    public class Author
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Surname { get; set; }
        public string About { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public ICollection<AuthorBook> Books { get; set; }
        public Contact Contact { get; set; }
    }
}
