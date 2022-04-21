using Domain;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SportFields.Queries.GetAllSportFields
{
    public class GetAllSportFieldsQueryHandler : IRequestHandler<GetAllSportFieldsQuery, List<SportField>>
    {
        private readonly ISportFieldRepository _repository;

        public GetAllSportFieldsQueryHandler(ISportFieldRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<SportField>> Handle(GetAllSportFieldsQuery query, CancellationToken cancellationToken)
        {
            return await _repository.GetAllSportFieldsAsync(cancellationToken);
        }
    }
}
