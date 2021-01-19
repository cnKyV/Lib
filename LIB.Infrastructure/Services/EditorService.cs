using LIB.Contracts.ResponseModel;
using LIB.Contracts.Shared;
using LIB.Core.Entities;
using LIB.Infrastructure.Interfaces;
using LIB.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace LIB.Infrastructure.Services
{
    public class EditorService : IEditorService
    {
        public ICreateModel Create(EditorRepository Repository)
        {
            throw new NotImplementedException();
        }

        public ICollection<EditorViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public EditorViewModel GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public IUpdateModel Update(EditorRepository Repository)
        {
            throw new NotImplementedException();
        }
    }
}
