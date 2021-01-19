using System;
using System.Collections.Generic;
using System.Text;

namespace LIB.Core.Entities
{
    public class Editor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string About { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public ICollection<BookEditor> Books { get; set; }
        public ICollection<EditorPublisher> Publishers { get; set; }
        public Contact Address { get; set; }
    }
}
