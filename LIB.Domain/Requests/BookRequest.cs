using System.Collections.Generic;
using LIB.Contracts.RequestModel;
using LIB.Contracts.ResponseModel;
using LIB.Domain.Interfaces;
using LIB.Infrastructure.Interfaces;

namespace LIB.Domain.Requests
{
    public class BookRequest : IBookRequest
    {
        private readonly IAuthorService _authorService;
        public BookRequest()
        {
            
        }
        public BookResponseModel CreateRequest(BookCreateModel author)
        {
            throw new System.NotImplementedException();
        }

        public BookResponseModel UpdateRequest(BookCreateModel author)
        {
            throw new System.NotImplementedException();
        }

        public BookResponseModel BookView(int id)
        {
            throw new System.NotImplementedException();
        }
        

        public bool Clear()
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteById(int id)
        {
            return _authorService.DeleteById(id);
        }

        public IEnumerable<BookResponseModel> BookViewMultiple()
        {
            throw new System.NotImplementedException();
        }
        
    }
}