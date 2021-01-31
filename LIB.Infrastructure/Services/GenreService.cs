using LIB.Contracts.ResponseModel;
using LIB.Contracts.Shared;
using LIB.Core.Entities;
using LIB.Infrastructure.Interfaces;
using LIB.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace LIB.Infrastructure.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;

        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }
        public Genre Create(Genre genre)
        {
            return genre is null ? null : _genreRepository.Create(genre);
        }

        public ICollection<Genre> GetAll()
        {
            return _genreRepository.GetAll();
        }

        public Genre GetById(int id)
        {
            return _genreRepository.GetById(id) is null ? null : _genreRepository.GetById(id);
        }

        public Genre Update(Genre genre)
        {
            return genre is null ? null : _genreRepository.Update(genre);
        }

        public IEnumerable<Genre> GetMultipleByIds(IEnumerable<int> ids)
        {
            return _genreRepository.GetMultipleByIds(ids);
        }
    }
}
