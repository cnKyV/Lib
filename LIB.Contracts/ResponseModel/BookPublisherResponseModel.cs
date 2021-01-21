using System;
using System.Collections.Generic;
using System.Text;

namespace LIB.Contracts.ResponseModel
{
   public class BookPublisherResponseModel
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int PublisherId { get; set; }
    }
}
