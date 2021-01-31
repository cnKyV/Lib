﻿using LIB.Core.Entities;
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
            _libDbContext.Genres.Add(genre);
            return genre;
        }

        public bool DeleteById(int id)
        {
            var result = _libDbContext.Genres.FirstOrDefault(i => i.Id == id);
            try
            {
                _libDbContext.Genres.Remove(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return false;
            }
            return true;
        }

        public IEnumerable<Genre> GetMultipleByIds(IEnumerable<int> ids)
        {
            return  _libDbContext.Genres.Where(i => ids.Contains(i.Id)).Select(i=>i).ToList();
        }

        public void SaveChanges()
        {
            _libDbContext.SaveChanges();
        }

        public ICollection<Genre> GetAll()
        {
            return _libDbContext.Genres.ToArray();
        }

        public Genre GetById(int id)
        {
            return _libDbContext.Genres.FirstOrDefault(i => i.Id == id);
        }

        public Genre Update(Genre genre)
        {
            var result = _libDbContext.Genres.FirstOrDefault(i=> i.Id == genre.Id);
            result.Name = genre.Name;
            result.Books = genre.Books;
            return result;
        }
    }
}
