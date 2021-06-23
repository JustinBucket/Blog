using System;
using AutoMapper;
using Blog.DTOs;
using Blog.Models;

namespace Blog.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Post, OutboundPostDto>()
                .ForMember(dest => dest.TypeString,
                    opt => opt.MapFrom(src => src.Type.ToString()));

            CreateMap<InboundPostDto, Post>()
                .ForMember(dest => dest.Type,
                opt => opt.MapFrom(src => Enum.Parse<MediaType>(src.MediaTypeString)));

        }
    }
}