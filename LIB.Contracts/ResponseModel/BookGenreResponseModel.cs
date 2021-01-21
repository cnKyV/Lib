using System;
using System.Collections.Generic;
using System.Text;

namespace LIB.Contracts.ResponseModel
{
   public class BookGenreResponseModel
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int GenreId { get; set; }
    }
}
