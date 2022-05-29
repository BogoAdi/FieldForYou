using Application.SportFields.Commands.CreateSportField;
using AutoMapper;
using Domain;
using FieldForYou.Api.Dto;
using SportFieldScheduler.Application.Dto;

namespace FieldForYou.Api.Profiles
{
    public class SportFieldProfile : Profile
    {
        public SportFieldProfile()
        {
            CreateMap<SportFieldPostDto, CreateSportFieldCommand>();
            CreateMap<SportField, SportFieldDto>();
        }
    }
}
