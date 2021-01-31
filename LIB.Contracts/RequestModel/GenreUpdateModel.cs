using LIB.Contracts.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace LIB.Contracts.RequestModel
{
    public class GenreUpdateModel : IUpdateModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<int> Books { get; set; }
    }
}
