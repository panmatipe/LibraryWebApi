using AutoMapper;
using Library.Domain.Entities;

namespace Library.Application.Dtos.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorDto>()
                .ForMember(m => m.Books, opt => opt.MapFrom(src => src.Books));
        }
    }
}
