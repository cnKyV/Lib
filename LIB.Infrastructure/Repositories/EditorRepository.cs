using LIB.Core.Entities;
using LIB.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace LIB.Infrastructure.Repositories
{
    public class EditorRepository : IEditorRepository
    {
        LibDBContext _libDbContext;
        public EditorRepository( LibDBContext libDbContext)
        {
            _libDbContext = libDbContext;
        }
        
        public Editor Create(Editor editor)
        {
           _libDbContext.Editors.Add(editor);
           return editor;
        }

        public bool DeleteById(int id)
        {
            var query = _libDbContext.Editors.Include(i=>i.Books).Include(i=>i.Publishers).Include(i=>i.Contact).FirstOrDefault(i => i.Id == id);
            try
            {
                _libDbContext.Editors.Remove(query);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public IEnumerable<Editor> GetMultipleByIds(IEnumerable<int> ids)
        {
            return  _libDbContext.Editors.Where(i => ids.Contains(i.Id)).Select(i=>i).ToList();
        }

        public void SaveChanges()
        {
            _libDbContext.SaveChanges();
        }

        public ICollection<Editor> GetAll()
        {
          return _libDbContext.Editors.Include(i=>i.Books).Include(i=>i.Publishers).Include(i=>i.Contact).ToArray();
        }

        public Editor GetById(int id)
        {
            return _libDbContext.Editors.Include(i=>i.Books).Include(i=>i.Publishers).Include(i=>i.Contact).FirstOrDefault(i => i.Id == id);
        }

        public Editor Update(Editor editor)
        {
            var query = _libDbContext.Editors.Include(i=>i.Books).Include(i=>i.Publishers).Include(i=>i.Contact).FirstOrDefault(i => i.Id == editor.Id);
            query.Name = editor.Name;
            query.Surname = editor.Surname;
            query.Contact = editor.Contact;
            query.About = editor.About;
            query.Publishers = editor.Publishers;
            query.Books = editor.Books;
            query.DateOfBirth = editor.DateOfBirth;
            return query;
        }
    }
}
