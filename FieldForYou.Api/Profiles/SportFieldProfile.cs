using AutoMapper;
using Domain;
using FieldForYou.Api.Dto;

namespace FieldForYou.Api.Profiles
{
    public class SportFieldProfile : Profile
    {
        public SportFieldProfile()
        {
            CreateMap<SportField, SportFieldDto>()
                .ReverseMap();
        }
    }
}
