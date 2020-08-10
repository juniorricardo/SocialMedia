using AutoMapper;
using SocialMedia.Core.DTOs;
using SocialMedia.Core.Entities;

namespace SocialMedia.Infrastructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            ///CreateMap<Entity, DTO>()
            CreateMap<Post, PostDTO>()
                .ForMember(dest =>
                    dest.PostId,
                    opt => opt.MapFrom(src => src.Id)
                );


            CreateMap<PostDTO, Post>()
                .ForMember(dest =>
                    dest.Id,
                    opt => opt.MapFrom(src => src.PostId)
                );
        }
    }
}
