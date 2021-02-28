using AutoMapper;
using LIB.Contracts.RequestModel;
using LIB.Contracts.ResponseModel;
using LIB.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LIB.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Author
            CreateMap<Author, AuthorResponseModel>()
                .ForMember(x => x.ContactId, j => j.MapFrom(i => i.Contact.Id));
                //.ForMember(model => model.Books, entity=> entity.MapFrom(i => new List<int>()));
            CreateMap<AuthorCreateModel, Author>()
                .ForMember(entity => entity.Books, model => model.MapFrom(i => new List<AuthorBook>())); 
            CreateMap<AuthorUpdateModel, Author>()
                .ForMember(entity => entity.Books, model => model.MapFrom(i => new List<AuthorBook>()));
            
            
            //Contact
            CreateMap<ContactCreateModel, Contact>();
            CreateMap<ContactUpdateModel, Contact>();
            CreateMap<Contact, ContactResponseModel>();
            
            //Book
            CreateMap<BookCreateModel, Book>()
                .ForMember(entity => entity.Authors, model => model.MapFrom(i => new List<AuthorBook>()))
                .ForMember(entity => entity.Genres, model => model.MapFrom(i => new List<BookGenre>()))
                .ForMember(entity => entity.Editors, model => model.MapFrom(i => new List<BookEditor>()))
                .ForMember(entity => entity.Publishers, model => model.MapFrom(i => new List<BookPublisher>()));            
            CreateMap<BookUpdateModel, Book>()
                .ForMember(entity => entity.Authors, model => model.MapFrom(i => new List<AuthorBook>()))
                .ForMember(entity => entity.Genres, model => model.MapFrom(i => new List<BookGenre>()))
                .ForMember(entity => entity.Editors, model => model.MapFrom(i => new List<BookEditor>()))
                .ForMember(entity => entity.Publishers, model => model.MapFrom(i => new List<BookPublisher>()));
            CreateMap<Book, BookResponseModel>();

            //Editor
            CreateMap<EditorCreateModel, Editor>()
                .ForMember(i => i.Books, k => k.MapFrom(j => new List<BookEditor>()))
                .ForMember(i => i.Publishers, k => k.MapFrom(j => new List<EditorPublisher>()));
            CreateMap<EditorUpdateModel, Editor>()
                .ForMember(i => i.Books, k => k.MapFrom(j => new List<BookEditor>()))
                .ForMember(i => i.Publishers, k => k.MapFrom(j => new List<EditorPublisher>()));
            CreateMap<Editor, EditorResponseModel>();
            
            //Genre
            CreateMap<GenreCreateModel, Genre>()
                .ForMember(i => i.Books, j => j.MapFrom(k => new List<BookGenre>()));
            CreateMap<GenreUpdateModel, Genre>()
                .ForMember(i => i.Books, j => j.MapFrom(k => new List<BookGenre>()));
            CreateMap<Genre, GenreResponseModel>();
           //Publisher
           CreateMap<PublisherCreateModel, Publisher>()
               .ForMember(i => i.Books, k => k.MapFrom(j => new List<BookPublisher>()))          
               .ForMember(i => i.Editors, k => k.MapFrom(j => new List<EditorPublisher>()));           
           CreateMap<PublisherUpdateModel, Publisher>()
               .ForMember(i => i.Books, k => k.MapFrom(j => new BookPublisher()))
               .ForMember(i => i.Editors, k => k.MapFrom(j => new EditorPublisher()));    
           CreateMap<Publisher, PublisherResponseModel>();
           //Shared
            CreateMap<AuthorBook, AuthorBookResponseModel>()
                .ForMember(model => model.AuthorId, entity => entity.MapFrom(i => i.Author.Id))
                .ForMember(model => model.BookId, entity => entity.MapFrom(i => i.Book.Id));
            CreateMap<BookEditor, BookEditorResponseModel>()
                .ForMember(model => model.BookId, entity => entity.MapFrom(i => i.Book.Id))
                .ForMember(model => model.EditorId, entity => entity.MapFrom(i => i.Editor.Id));

            CreateMap<BookGenre, BookGenreResponseModel>()
                .ForMember(model => model.BookId, entity => entity.MapFrom(i => i.Book.Id))
                .ForMember(model => model.GenreId, entity => entity.MapFrom(i => i.Genre.Id));
            CreateMap<BookPublisher, BookPublisherResponseModel>()
                .ForMember(model => model.BookId, entity => entity.MapFrom(i => i.Book.Id))
                .ForMember(model => model.PublisherId, entity => entity.MapFrom(i => i.Publisher.Id));

            CreateMap<EditorPublisher, EditorPublisherResponseModel>()
                .ForMember(m => m.EditorId, e => e.MapFrom(i => i.Editor.Id))
                .ForMember(m => m.PublisherId, e => e.MapFrom(i => i.Publisher.Id));
            


            //<model,entity> .ForMember(entity => entity.Books, model => model.MapFrom(i => new List<AuthorBook>()));
        }

    }
}
