using AutoMapper;

using BookLibrary.Data.Models;
using BookLibrary.Db.Models;

namespace BookLibrary.Data
{
    internal class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Author, AuthorModel>().ReverseMap();
            CreateMap<Book, BookModel>().ReverseMap();
            CreateMap<BinaryFile, FileModel>().ReverseMap();
        }
    }
}
