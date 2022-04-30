using Domain;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SportFields.Queries.GetSportFieldById
{
    public class GetSportFieldByIdQueryHandler : IRequestHandler<GetSportFieldByIdQuery, SportField>
    {
        private readonly ISportFieldRepository _repository;
        public GetSportFieldByIdQueryHandler(ISportFieldRepository repository)
        {
            _repository = repository;
        }
        public async Task<SportField> Handle(GetSportFieldByIdQuery query, CancellationToken cancellationToken)
        {
            var sportField = _repository.GetSportFieldByIdAsync(query.Id, cancellationToken);
            return await sportField;
        }
    }
}
