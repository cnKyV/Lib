using LIB.Contracts.RequestModel;
using LIB.Contracts.ResponseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace LIB.Domain.Interfaces
{
    public interface IAuthorRequest
    {
        public AuthorResponseModel CreateRequest(AuthorCreateModel author);
        public AuthorResponseModel UpdateRequest(AuthorUpdateModel author);
    }
}
