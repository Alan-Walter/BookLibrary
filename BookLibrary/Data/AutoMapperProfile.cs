using AutoMapper;

using BookLibrary.Data.Models;
using BookLibrary.Db.Models;

namespace BookLibrary.Data
{
    internal class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BookGroup, BookGroupModel>().ReverseMap();
        }
    }
}
