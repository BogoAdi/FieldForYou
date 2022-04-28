using Application.Users.Commands.CreateUser;
using AutoMapper;
using Domain;
using FieldForYou.Api.Dto;

namespace FieldForYou.Api.Profiles
{
    public class UserProfile : Profile
    {
            public UserProfile()
            {
                CreateMap<UserPutPostDto, CreateUserCommand>();
                CreateMap<User, UserGetDto>();
                //  CreateMap<Appointment, UserAppointmentDto>();

            }
    }
}
