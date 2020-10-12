using AutoMapper;
using GoogleBooksApplication.Models;
using GoogleBooksDomain;

namespace GoogleBooksApplication.Mappers
{
    public class BooksMapper : Profile
    {
        public BooksMapper()
        {
            CreateMap<BookModel, Book>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.GoogleId, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(x => x.VolumeInfo.Title))
                .ForMember(dest => dest.Thumbnail, opt => opt.MapFrom(x => x.VolumeInfo.ImageLinks.Thumbnail))
                .ReverseMap();
        }
    }
}
