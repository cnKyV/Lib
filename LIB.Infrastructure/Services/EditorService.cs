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
        public Editor Create(Editor editor)
        {
            var result =_editorRepository.Create(editor);
            _editorRepository.SaveChanges();
            return result;
        }

        public ICollection<Editor> GetAll()
        {
            return _editorRepository.GetAll();
        }

        public Editor GetById(int Id)
        {
            return _editorRepository.GetById(Id);
        }

        public Editor Update(Editor editor)
        {
            return _editorRepository.Update(editor);
        }

        public IEnumerable<Editor> GetMultipleByIds(IEnumerable<int> ids)
        {
            return _editorRepository.GetMultipleByIds(ids);
        }
    }
}
