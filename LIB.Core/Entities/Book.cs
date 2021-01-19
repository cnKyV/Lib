using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LIB.Core.Entities
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int Pages { get; set; }
        public string PdfSource { get; set; }
        public string Edition { get; set; }
        public ICollection<AuthorBook> Authors { get; set; }
        public ICollection<BookEditor> Editors { get; set; }
        public ICollection<BookPublisher> Publishers { get; set; }
        public ICollection<BookGenre> Genres { get; set; }
        public ICollection<BookLibrary> Libraries { get; set; }
    }
}
