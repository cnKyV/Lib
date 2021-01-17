﻿using LIB.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LIB.Infrastructure.Interfaces
{
    interface IGenreService
    {
        ICollection<Genre> GetAll();
        Genre GetById(int id);
        Genre Create(Genre genre);
        Genre Update(Genre genre);
        bool Clear();
        bool DeleteById(int id);
    }
}