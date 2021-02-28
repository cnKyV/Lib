using System.Collections.Generic;
using LIB.Contracts.RequestModel;
using LIB.Contracts.ResponseModel;

namespace LIB.Domain.Interfaces
{
    public interface IGenreRequest
    {
        public GenreResponseModel CreateRequest(GenreCreateModel genre);
        public GenreResponseModel UpdateRequest(GenreUpdateModel genre);
        public GenreResponseModel GenreView(int id);
        bool DeleteById(int id);
        public IEnumerable<GenreResponseModel> GenreView();
    }
}