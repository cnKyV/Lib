using LIB.Contracts.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace LIB.Contracts.RequestModel
{
    public class PublisherUpdateModel : IUpdateModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public ICollection<int> Editors { get; set; }
        public ICollection<int> Books { get; set; }
        public int ContactId { get; set; }
    }
}
