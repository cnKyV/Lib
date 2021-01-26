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
        private readonly IEditorRepository _editorRepository;

        public EditorService(IEditorRepository editorRepository)
        {
            _editorRepository = editorRepository;
        }
        public Editor Create(Editor author)
        {
            throw new NotImplementedException();
        }

        public ICollection<Editor> GetAll()
        {
            throw new NotImplementedException();
        }

        public Editor GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Editor Update(Editor author)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Editor> GetMultipleByIds(IEnumerable<int> ids)
        {
            return _editorRepository.GetMultipleByIds(ids);
        }
    }
}
