using System.Collections.Generic;
using AutoMapper;
using LIB.Contracts.RequestModel;
using LIB.Contracts.ResponseModel;
using LIB.Core.Entities;
using LIB.Domain.Interfaces;
using LIB.Infrastructure.Interfaces;
using LIB.Infrastructure.Services;

namespace LIB.Domain.Requests
{
    public class GenreRequest : IGenreRequest
    {
        private readonly IGenreService _genreService;
        private readonly IMapper _mapper;

        public GenreRequest(IGenreService genreService, IMapper mapper)
        {
            _genreService = genreService;
            _mapper = mapper;
        }
        public GenreResponseModel CreateRequest(GenreCreateModel genre)
        {
            _mapper.Map<Genre>(genre);
            return null;
        }

        public GenreResponseModel UpdateRequest(GenreUpdateModel genre)
        {
            throw new System.NotImplementedException();
        }

        public GenreResponseModel GenreView(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Clear()
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<GenreResponseModel> GenreViewMultiple()
        {
            throw new System.NotImplementedException();
        }
    }
}