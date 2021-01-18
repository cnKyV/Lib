using Microsoft.Extensions.Logging;
using LIB.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LIB.Infrastructure.Repositories
{
    public class GeneralRepository<T> : IGeneralRepository<T>
    {
        ILogger _logger;
        LibDBContext _libDbContext;
        public GeneralRepository(ILogger logger, LibDBContext libDBContext)
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

        public T Update(T TEntity)
        {
            throw new NotImplementedException();
        }
    }
}
