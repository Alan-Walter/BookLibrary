using AntDesign;

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
            CreateMap<UploadFileItem, BinaryFileModel>()
                .ForMember(dest => dest.FileName, opt => opt.MapFrom(i => i.FileName))
                .ForMember(dest => dest.FilePath, opt => opt.MapFrom(i => i.Url))
                .ForMember(dest => dest.FileType, opt => opt.MapFrom(i => i.Type))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(i => i.Id))
                .ReverseMap();
        }
    }
}
