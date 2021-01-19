using LIB.Core.Entities;
using LIB.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LIB.Infrastructure.Repositories
{
    public class EditorRepository : IRepository<Editor>
    {
        LibDBContext _libDbContext;
        ILogger<Editor> _logger;
        public EditorRepository(ILogger<Editor> logger, LibDBContext libDbContext)
        {
            _libDbContext = libDbContext;
            _logger = logger;
        }
        public bool Clear()
        {
            try
            {
                _libDbContext.Editors.RemoveRange(_libDbContext.Editors);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return false;
            }
            _logger.LogInformation($"Editors have been wiped out succesfully by {Environment.UserName} / {Environment.UserDomainName}");
            return true;
        }

        public Editor Create(Editor editor)
        {
            try
            {
                _libDbContext.Editors.Add(editor);
                _libDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,ex.Message);
                return null;
            }
            return editor;
        }

        public bool DeleteById(int id)
        {
            var query = _libDbContext.Editors.FirstOrDefault(i => i.Id == id);
            try
            {
                _libDbContext.Editors.Remove(query);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return false;
            }
            return true;
        }

        public ICollection<Editor> GetAll()
        {
            var query = _libDbContext.Editors.ToArray();
            try
            {
                return query;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }

        public Editor GetById(int id)
        {
            var query = _libDbContext.Editors.FirstOrDefault(i => i.Id == id);
            try
            {
                return query;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }

        public Editor Update(Editor editor)
        {
            var query = _libDbContext.Editors.FirstOrDefault(i => i.Id == editor.Id);
            query.Name = editor.Name;
            query.Surname = editor.Surname;
            query.Address = editor.Address;
            query.About = editor.About;
            try
            {
                _libDbContext.SaveChanges();
                return query;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }
    }
}
