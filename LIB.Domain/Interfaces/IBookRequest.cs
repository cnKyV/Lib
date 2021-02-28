using System.Collections.Generic;
using LIB.Contracts.RequestModel;
using LIB.Contracts.ResponseModel;

namespace LIB.Domain.Interfaces
{
    public interface IBookRequest
    {
        public BookResponseModel CreateRequest(BookCreateModel book);
        public BookResponseModel UpdateRequest(BookUpdateModel book);
        public BookResponseModel BookView(int id);
        bool DeleteById(int id);
        public IEnumerable<BookResponseModel> BookViewMultiple();
    }
}