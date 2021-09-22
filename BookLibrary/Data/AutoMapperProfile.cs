using AutoMapper;

using BookLibrary.Data.Models;
using BookLibrary.Db.Models;

namespace BookLibrary.Data
{
    internal class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BookGroup, BookGroupModel>();
            CreateMap<BookGroupModel, BookGroup>().ForMember(i => i.Parent, opt => opt.Ignore());
            CreateMap<Author, AuthorModel>().ReverseMap();
            CreateMap<Genre, GenreModel>().ReverseMap();
            CreateMap<Book, BookModel>().ReverseMap();
        }
    }
}
