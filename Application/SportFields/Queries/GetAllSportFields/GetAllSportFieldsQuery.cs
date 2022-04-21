using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SportFields.Queries.GetAllSportFields
{
    public class GetAllSportFieldsQuery : IRequest<List<SportField>>
    {
    }
}
