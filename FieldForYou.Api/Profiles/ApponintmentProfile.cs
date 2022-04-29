using AutoMapper;
using Domain;
using FieldForYou.Api.Dto;

namespace FieldForYou.Api.Profiles
{
    public class ApponintmentProfile : Profile
    {
        public ApponintmentProfile()
        {
            CreateMap<Appointment, AppointmentDto>()
                .ReverseMap();
        }
    }
}
