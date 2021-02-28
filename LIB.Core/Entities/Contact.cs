using System;
using System.Collections.Generic;
using System.Text;

namespace LIB.Core.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Number1 { get; set; }
        public string Number2 { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
    }
}
