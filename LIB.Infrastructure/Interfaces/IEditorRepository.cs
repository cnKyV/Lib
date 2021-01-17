using LIB.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LIB.Infrastructure.Interfaces
{
    public interface IEditorRepository
    {
        ICollection<Editor> GetAll();
        Editor GetById(int id);
        Editor Create(Editor editor);
        Editor Update(Editor editor);
        bool Clear();
        bool DeleteById(int id);
        void SaveChanges();
    }
}
