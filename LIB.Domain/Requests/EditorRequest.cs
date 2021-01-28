using System.Collections.Generic;
using AutoMapper;
using LIB.Contracts.RequestModel;
using LIB.Contracts.ResponseModel;
using LIB.Core.Entities;
using LIB.Domain.Interfaces;
using LIB.Infrastructure.Interfaces;
using LIB.Infrastructure.Services;

namespace LIB.Domain.Requests
{
    public class EditorRequest : IEditorRequest
    {
        private readonly IMapper _mapper;
        private readonly IEditorService _editorService;
        private readonly IPublisherService _publisherService;
        private readonly IBookService _bookService;

        public EditorRequest( IMapper mapper, IEditorService editorService, IPublisherService publisherService, IBookService bookService)
        {
            _mapper = mapper;
            _editorService = editorService;
            _publisherService = publisherService;
            _bookService = bookService;
        }
        
        public EditorResponseModel CreateRequest(EditorCreateModel editor)
        {
            var tbcEditor = _mapper.Map<Editor>(editor);

            
            var eBook = _bookService.GetMultipleByIds(editor.Books);
            var ePublisher = _publisherService.GetMultipleByIds(editor.Publishers);
            foreach (var book in eBook)
            {
                var moq = new BookEditor();
                moq.Book = book;
                tbcEditor.Books.Add(moq);
            }
            foreach (var publisher in ePublisher)
            {
                var moq = new EditorPublisher();
                moq.Publisher = publisher;
                tbcEditor.Publishers.Add(moq);
            }
            

            _editorService.Create(tbcEditor);

            return _mapper.Map<EditorResponseModel>(tbcEditor);

        }

        public EditorResponseModel UpdateRequest(EditorUpdateModel editor)
        {
            throw new System.NotImplementedException();
        }

        public EditorResponseModel AuthorView(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Clear()
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<EditorResponseModel> AuthourViewMultiple()
        {
            throw new System.NotImplementedException();
        }
    }
}