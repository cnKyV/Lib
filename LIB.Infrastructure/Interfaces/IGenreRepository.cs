﻿using LIB.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LIB.Infrastructure.Interfaces
{
    public interface IGenreRepository
    {
        ICollection<Genre> GetAll();
        Genre GetById(int id);
        Genre Create(Genre TEntity);
        Genre Update(Genre TEntity);
        bool DeleteById(int id);
        public IEnumerable<Genre> GetMultipleByIds(IEnumerable<int> ids);
        void SaveChanges();

    }
}
