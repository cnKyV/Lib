using LIB.Core.Entities;
using LIB.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LIB.Infrastructure.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        ILogger<Genre> _logger;
        LibDBContext _libDbContext;
        public GenreRepository(ILogger<Genre> logger, LibDBContext libDbContext)
        {
            _logger = logger;
            _libDbContext = libDbContext;
        }
        public bool Clear()
        {
            try
            {
                _libDbContext.Genres.RemoveRange(_libDbContext.Genres);
                _libDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return false;

            }
            _logger.LogInformation($"Genres have been wiped out succesfully by {Environment.UserName} / {Environment.UserDomainName}");
            return true;
        }


        public Genre Create(Genre genre)
        {
            try
            {
                _libDbContext.Genres.Add(genre);
                _libDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
            return genre;
        }

        public bool DeleteById(int id)
        {
            var result = _libDbContext.Genres.FirstOrDefault(i => i.Id == id);
            try
            {
                _libDbContext.Genres.Remove(result);
                _libDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return false;
            }
            _logger.LogInformation($"Record with {id} ID has been removed succesfully by {Environment.UserName} / {Environment.UserDomainName}");
            return true;
        }

        public IEnumerable<Genre> GetMultipleByIds(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public ICollection<Genre> GetAll()
        {
            try
            {
                return _libDbContext.Genres.ToArray();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }

        public Genre GetById(int id)
        {
            var result = _libDbContext.Genres.FirstOrDefault(i => i.Id == id);
            try
            {
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }


        }

        public Genre Update(Genre genre)
        {
            var result = _libDbContext.Genres.FirstOrDefault(i=> i.Id == genre.Id);

            result.Name = genre.Name;
            result.Books = genre.Books;
            try
            {
                _libDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
            return result;
        }
    }
}
