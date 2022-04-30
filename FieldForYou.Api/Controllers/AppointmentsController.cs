using Application.Appointments.Commands.CreateAppointment;
using Application.Appointments.Commands.DeleteAppointment;
using Application.Appointments.Queries.GetAllAppointments;
using Application.Appointments.Queries.GetAppointmentById;
using AutoMapper;
using Domain;
using FieldForYou.Api.Dto;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FieldForYou.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {

        public readonly IMediator _mediator;
        public readonly IMapper _mapper;

        public AppointmentsController(IMapper mapper, IMediator mediator)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppointment(AppointmentDto appointmentDto)
        {
            var appointment = _mapper.Map<Appointment>(appointmentDto);

            var command = new CreateAppointmentCommand
            {
                SportFieldId = appointment.SportFieldId,
                UserId = appointment.UserId,
                Date = appointment.Date,
                Hours = appointment.Hours,
                TotalPrice = appointment.TotalPrice
            };
            var resultAppointment = await _mediator.Send(command);

            return Created($"/api/[controller]/{resultAppointment.Id}", null);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAppointments()
        {
            var appointmentList = await _mediator.Send(new GetAllAppointmentsQuery());
            var mappedAppointments = _mapper.Map<List<AppointmentDto>>(appointmentList);

            return Ok(mappedAppointments);
        }

        [HttpGet("{appointmentId}")]
        public async Task<IActionResult> GetAppointment(Guid appointmentId)
        {
            var appointment = await _mediator.Send(new GetAppointmentByIdQuery { Id = appointmentId });
            var mappedAppointment = _mapper.Map<AppointmentDto>(appointment);

            return Ok(mappedAppointment);
        }

        [HttpDelete("{appointmentId}")]
        public async Task<IActionResult> DeleteAppointment(Guid appointmentId)
        {
            await _mediator.Send(new DeleteAppointmentCommand { Id = appointmentId });
            return NoContent();
        }

        /*[HttpPatch("{appointmentId}")]
        public async Task<IActionResult> UpdateAppointment(Guid appointmentId, AppointmentDto appointmentDto)
        {
            var mappedAppointment = _mapper.Map<Appointment>(appointmentDto);

        NU E FACUTA COMANDA DE UPDATE !!!
            
        }*/
    }
}
