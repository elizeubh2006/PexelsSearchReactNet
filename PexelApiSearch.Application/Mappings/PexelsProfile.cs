using AutoMapper;
using PexelApiSearch.Application.PexelsServices.DTOs;
using PexelApiSearch.Domain.Entities;

namespace PexelApiSearch.Application.Mappings
{
    public class PexelsProfile : Profile
    {
        public PexelsProfile()
        {
            // Mapeia PexelsPhoto → PexelsSearchResult
            CreateMap<PexelsPhoto, PexelsSearchResult>()
                .ForMember(dest => dest.SearchDate, opt => opt.MapFrom(_ => DateTime.UtcNow))
                .ForMember(dest => dest.OriginalUrl, opt => opt.MapFrom(src => src.Src.Original))
                .ForMember(dest => dest.ThumbnailUrl, opt => opt.MapFrom(src => src.Src.Tiny))
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Photographer))
                .ForMember(dest => dest.Width, opt => opt.MapFrom(src => src.Width))
                .ForMember(dest => dest.Height, opt => opt.MapFrom(src => src.Height))
                .ForMember(dest => dest.ElapsedSeconds, opt => opt.Ignore()); 
        }
    }
}
