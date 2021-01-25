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
            CreateMap<Author, AuthorResponseModel>()
                .ForMember(model => model.Books, entity=> entity.MapFrom(i => new List<int>()));
            CreateMap<AuthorCreateModel, Author>()
                .ForMember(entity => entity.Books, model => model.MapFrom(i => new List<AuthorBook>())); 
            CreateMap<AuthorUpdateModel, Author>()
                .ForMember(entity => entity.Books, model => model.MapFrom(i => new List<AuthorBook>()));
            CreateMap<ContactCreateModel, Contact>();
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
            CreateMap<Book, BookResponseModel>()
                .ForMember(model => model.Authors, entity => entity.MapFrom(i => new List<int>()))
                .ForMember(model => model.Genres, entity => entity.MapFrom(i => new List<int>()))
                .ForMember(model => model.Editors, entity => entity.MapFrom(i => new List<int>()))
                .ForMember(model => model.Publishers, entity => entity.MapFrom(i => new List<int>()));





            //<model,entity> .ForMember(entity => entity.Books, model => model.MapFrom(i => new List<AuthorBook>()));
        }

    }
}
