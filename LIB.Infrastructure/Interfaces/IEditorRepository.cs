﻿using LIB.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LIB.Infrastructure.Interfaces
{
    public interface IEditorRepository
    {
        ICollection<Editor> GetAll();
        Editor GetById(int id);
        Editor Create(Editor TEntity);
        Editor Update(Editor TEntity);
        bool DeleteById(int id);
        public IEnumerable<Editor> GetMultipleByIds(IEnumerable<int> ids);
        void SaveChanges();

    }
}
