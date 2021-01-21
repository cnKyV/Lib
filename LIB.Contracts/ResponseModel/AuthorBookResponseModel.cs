using LIB.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LIB.Contracts.ResponseModel
{
    public class AuthorBookResponseModel
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public int BookId { get; set; }
    }
}
