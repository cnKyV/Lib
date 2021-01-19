using Microsoft.Extensions.Logging;
using LIB.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LIB.Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T>
    {
        ILogger<T> _logger;
        LibDBContext _libDbContext;
        public BaseRepository(ILogger<T> logger, LibDBContext libDBContext)
        {
            _logger = logger;
            _libDbContext = libDBContext;
 
        }
        public bool Clear()
        {
            throw new NotImplementedException();
        }

        public T Create(T TEntity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        protected virtual T Update(T TEntity)
        {
            throw new NotImplementedException();
        }
    }
}
