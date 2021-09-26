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
            // entities -> models
            CreateMap<BookGroup, BookGroupModel>();
            CreateMap<BookGroupModel, BookGroup>()
                .ForMember(i => i.Parent, opt => opt.Ignore());
            CreateMap<Author, AuthorModel>()
                .ReverseMap();
            CreateMap<Genre, GenreModel>()
                .ReverseMap();
            CreateMap<Book, BookModel>()
                .ReverseMap();
            CreateMap<BinaryFile, BinaryFileModel>()
                .ReverseMap();

            CreateMap<BinaryFileModel, UploadFileItem>()
                .ForMember(dest => dest.FileName, opt => opt.MapFrom(i => i.FileName))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(i => i.FileType))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(i => i.Id))
                .AfterMap((src, dst) => dst.Url = $"/api/BinaryFile/{src.Id}")
                .ReverseMap();
        }
    }
}
