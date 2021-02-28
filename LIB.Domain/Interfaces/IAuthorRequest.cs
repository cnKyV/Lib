using LIB.Contracts.RequestModel;
using LIB.Contracts.ResponseModel;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using LIB.Core.Entities;

namespace LIB.Domain.Interfaces
{
    public interface IAuthorRequest
    {
        public AuthorResponseModel CreateRequest(AuthorCreateModel author);
        public AuthorResponseModel UpdateRequest(AuthorUpdateModel author);
        public AuthorResponseModel AuthorView(int id);
        bool DeleteById(int id);
        public IEnumerable<AuthorResponseModel> AuthourViewMultiple();
    }
}
