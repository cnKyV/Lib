using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LIB.Core.Entities
{
    public class AuthorBook
    {
        public int Id { get; set; }
        public Author Author { get; set; }
        public Book Book { get; set; }
    }
}
