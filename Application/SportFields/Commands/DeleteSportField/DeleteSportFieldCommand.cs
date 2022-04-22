using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SportFields.Commands.DeleteSportField
{
    public class DeleteSportFieldCommand : IRequest<SportField>
    {
        public Guid Id { get; set; }
    }
}
