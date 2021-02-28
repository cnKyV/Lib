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
            Populate(editor,tbcEditor);
            _editorService.Create(tbcEditor);
            return _mapper.Map<EditorResponseModel>(tbcEditor);
        }

        public EditorResponseModel UpdateRequest(EditorUpdateModel editor)
        {
           var tbcEditor = _mapper.Map<Editor>(editor);
           Populate(editor,tbcEditor);
           _editorService.Update(tbcEditor);
           return _mapper.Map<EditorResponseModel>(tbcEditor);
        }

        public EditorResponseModel EditorView(int id)
        {
            return _mapper.Map<EditorResponseModel>(_editorService.GetById(id));
        }

        public bool DeleteById(int id)
        {
            return _editorService.DeleteById(id);
        }

        public IEnumerable<EditorResponseModel> EditorViewMultiple()
        {
            return _mapper.Map<IEnumerable<EditorResponseModel>>(_editorService.GetAll());
        }

        void Populate(EditorCreateModel editor, Editor tbcEditor)
        {
            var eBook = _bookService.GetMultipleByIds(editor.Books);
            var ePublisher = _publisherService.GetMultipleByIds(editor.Publishers);
            foreach (var book in eBook)
            {
                var moq = new BookEditor {Book = book};
                tbcEditor.Books.Add(moq);
            }
            foreach (var publisher in ePublisher)
            {
                var moq = new EditorPublisher {Publisher = publisher};
                tbcEditor.Publishers.Add(moq);
            }
        }        
        void Populate(EditorUpdateModel editor, Editor tbcEditor)
        {
            var eBook = _bookService.GetMultipleByIds(editor.Books);
            var ePublisher = _publisherService.GetMultipleByIds(editor.Publishers);
            foreach (var book in eBook)
            {
                var moq = new BookEditor {Book = book};
                tbcEditor.Books.Add(moq);
            }
            foreach (var publisher in ePublisher)
            {
                var moq = new EditorPublisher {Publisher = publisher};
                tbcEditor.Publishers.Add(moq);
            }
        }
    }
}