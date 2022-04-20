using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var _diContainer = new ServiceCollection()
           .AddDbContext<FieldForYouContext>(options => options.UseSqlServer("Data Source=(localdb)\\ProjectModels;Initial Catalog=FieldForYouDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
             // .AddMediatR(typeof(CreateAppointmentCommand))
             //  .AddScoped<IAppointmentRepository, AppointmentRepository>()
             .BuildServiceProvider();

        // var _mediator = _diContainer.GetRequiredService<IMediator>();
