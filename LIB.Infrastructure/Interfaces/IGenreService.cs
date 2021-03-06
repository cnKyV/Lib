﻿using LIB.Contracts.ResponseModel;
using LIB.Contracts.Shared;
using LIB.Core.Entities;
using LIB.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace LIB.Infrastructure.Interfaces
{
    public interface IGenreService 
    {
        ICollection<Genre> GetAll();
        Genre GetById(int Id);
        Genre Create(Genre author);
        Genre Update(Genre author);
        bool DeleteById(int id);
        public IEnumerable<Genre> GetMultipleByIds(IEnumerable<int> ids);
    }
}
