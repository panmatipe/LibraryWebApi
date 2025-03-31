using AutoMapper;
using Library.Domain.Entities;

namespace Library.Application.Dtos.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookDto>()
                .ForMember(k => k.AuthorFirstName, opt => opt.MapFrom(src =>  src.Author.FirstName))
                .ForMember(k => k.AuthorLastName, opt => opt.MapFrom(src => src.Author.LastName));

            CreateMap<AddBookDto, Book>()
                .ForMember(k => k.Author, opt => opt.MapFrom(
                    src => new Author
                    {
                        FirstName = src.AuthorFirstName,
                        LastName = src.AuthorLastName,
                    }));

            CreateMap<UpdateBookDto, Book>();
        }
    }
}
