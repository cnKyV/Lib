using LIB.Contracts.Shared;
using LIB.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LIB.Contracts.ResponseModel
{
    public class AuthorResponseModel : ICreateModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string About { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public ICollection<AuthorBookResponseModel> Books { get; set; }
        public int ContactId { get; set; }
    }
}
