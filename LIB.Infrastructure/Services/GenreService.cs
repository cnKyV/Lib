using LIB.Contracts.ResponseModel;
using LIB.Contracts.Shared;
using LIB.Core.Entities;
using LIB.Infrastructure.Interfaces;
using LIB.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Serilog;

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
            var result = _genreRepository.Create(genre);        
            _genreRepository.SaveChanges();
            return result;
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
            var result = _genreRepository.Update(genre);
            if (result is null)
            {
                Log.Information($"Genre with Id:{genre.Id} does not exist");
                return null;
            }
            _genreRepository.SaveChanges();
            return result;
        }

        public IEnumerable<Genre> GetMultipleByIds(IEnumerable<int> ids)
        {
            return _genreRepository.GetMultipleByIds(ids);
        }
    }
}
