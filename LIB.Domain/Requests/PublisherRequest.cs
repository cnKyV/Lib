using System.Collections.Generic;
using AutoMapper;
using LIB.Contracts.RequestModel;
using LIB.Contracts.ResponseModel;
using LIB.Core.Entities;
using LIB.Domain.Interfaces;
using LIB.Infrastructure.Services;

namespace LIB.Domain.Requests
{
    public class PublisherRequest : IPublisherRequest
    {
        private readonly PublisherService _publisherService;
        private readonly BookService _bookService;
        private readonly EditorService _editorService;
        private readonly IMapper _mapper;

        public PublisherRequest(PublisherService publisherService, BookService bookService, EditorService editorService, IMapper mapper)
        {
            _bookService = bookService;
            _editorService = editorService;
            _publisherService = publisherService;
            _mapper = mapper;
        }
        
        public IEnumerable<PublisherResponseModel> View()
        {
            return _mapper.Map<IEnumerable<PublisherResponseModel>>(_publisherService.GetAll());
        }

        public PublisherResponseModel View(int id)
        {
            return _mapper.Map<PublisherResponseModel>(_publisherService.GetById(id));
        }

        public PublisherResponseModel Create(PublisherCreateModel createModel)
        {
            var result = _mapper.Map<Publisher>(createModel);
            Populate(createModel, result);
            _publisherService.Create(result);
            return _mapper.Map<PublisherResponseModel>(result);
        }
        public PublisherResponseModel Update(PublisherUpdateModel updateModel)
        {
            var result = _mapper.Map<Publisher>(updateModel);
            Populate(updateModel, result);
            _publisherService.Update(result);
            return _mapper.Map<PublisherResponseModel>(result);
        }

        public bool DeleteById(int id)
        {
            return _publisherService.DeleteById(id);
        }
        private void Populate(PublisherCreateModel createModel, Publisher publisher)
        {
            var getBooks = _bookService.GetMultipleByIds(createModel.Books);
            var getEditors = _editorService.GetMultipleByIds(createModel.Editors);
            foreach (var book in getBooks)
            {
                var moq = new BookPublisher();
                moq.Book = book;
                publisher.Books.Add(moq);
            }

            foreach (var editor in getEditors)
            {
                var moq = new EditorPublisher();
                moq.Editor = editor;
                publisher.Editors.Add(moq);
            }
        }        
        private void Populate(PublisherUpdateModel createModel, Publisher publisher)
        {
            var getBooks = _bookService.GetMultipleByIds(createModel.Books);
            var getEditors = _editorService.GetMultipleByIds(createModel.Editors);
            foreach (var book in getBooks)
            {
                var moq = new BookPublisher();
                moq.Book = book;
                publisher.Books.Add(moq);
            }

            foreach (var editor in getEditors)
            {
                var moq = new EditorPublisher();
                moq.Editor = editor;
                publisher.Editors.Add(moq);
            }
        }
    }
}