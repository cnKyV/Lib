using LIB.Contracts.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using LIB.Core.Entities;

namespace LIB.Contracts.ResponseModel
{
    public class GenreResponseModel : ICreateModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<BookGenreResponseModel> Books { get; set; }
        
        
    }
}
