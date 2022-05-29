using Application.Appointments.Commands.CreateAppointment;
using AutoMapper;
using Domain;
using FieldForYou.Api.Dto;

namespace FieldForYou.Api.Profiles
{
    public class ApponintmentProfile : Profile
    {
        public ApponintmentProfile()
        {
            CreateMap<AppointmentPostDto, CreateAppointmentCommand>();
            CreateMap<Appointment, AppointmentDto>();
        }
    }
}
