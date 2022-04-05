using Application.Appointments.Commands.CreateAppointment;
using Domain.RepositoryPattern;
using Infrastructure.DataAccess;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var _diContainer = new ServiceCollection()
               .AddMediatR(typeof(CreateAppointmentCommand))
               .AddScoped<IAppointmentRepository, AppointmentRepository>()
               .BuildServiceProvider();

            var _mediator = _diContainer.GetRequiredService<IMediator>();

            var appointmentId1 = await _mediator.Send(new CreateAppointmentCommand
            {
                ClientName = "Radu"
            });

            var appointmentId2 = await _mediator.Send(new CreateAppointmentCommand
            {
                ClientName = "Ovi"
            });


        }
    }
}
