using LIB.Contracts.ResponseModel;
using LIB.Contracts.Shared;
using LIB.Core.Entities;
using LIB.Infrastructure.Interfaces;
using LIB.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using Serilog;
using ILogger = Serilog.ILogger;

namespace LIB.Infrastructure.Services
{
    public class EditorService : IEditorService
    {
        private readonly IEditorRepository _editorRepository;
        private readonly ILogger<IEditorService> _logger;

        public EditorService(IEditorRepository editorRepository, ILogger<IEditorService> logger)
        {
            _editorRepository = editorRepository;
            _logger = logger;
        }
        public Editor Create(Editor editor)
        {
            var result =_editorRepository.Create(editor);
            SaveChanges();
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
            var result = _editorRepository.Update(editor);
            SaveChanges();
            return result;
        }

        public IEnumerable<Editor> GetMultipleByIds(IEnumerable<int> ids)
        {
            return _editorRepository.GetMultipleByIds(ids);
        }

        public bool DeleteById(int id)
        {
            var result = _editorRepository.DeleteById(id);
            SaveChanges();
            return result;
        }

        public void SaveChanges()
        {
            try
            {
                _editorRepository.SaveChanges();
            }
            catch (Exception e)
            {
                _logger.LogInformation(e, e.Message);
            }
            
        }
    }
}
