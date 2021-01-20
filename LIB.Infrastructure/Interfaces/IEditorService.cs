using LIB.Contracts.ResponseModel;
using LIB.Contracts.Shared;
using LIB.Core.Entities;
using LIB.Infrastructure.Repositories;
using System.Collections.Generic;

namespace LIB.Infrastructure.Interfaces
{
   public interface IEditorService
    {
        ICollection<Editor> GetAll();
        Editor GetById(int Id);
        Editor Create(Editor author);
        Editor Update(Editor author);
    }
}
