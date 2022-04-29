using Application.SportFields.Commands.DeleteSportField;
using Application.SportFields.Queries.GetAllSportFields;
using Application.SportFields.Queries.GetSportFieldById;
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
    public class SportFieldsController : ControllerBase
    {

        public readonly IMediator _mediator;
        public readonly IMapper _mapper;

        public SportFieldsController(IMapper mapper, IMediator mediator)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSportFields()
        {
            var sportFieldsList = await _mediator.Send(new GetAllSportFieldsQuery());
            var mappedsportFieldList = _mapper.Map<List<SportFieldDto>>(sportFieldsList);

            return Ok(mappedsportFieldList);
        }

        [HttpGet("{sportFieldId}")]
        public async Task<IActionResult> GetSportField(Guid sportFieldId)
        {
            var sportField = await _mediator.Send(new GetSportFieldByIdQuery { Id = sportFieldId});
            var mappedsportField = _mapper.Map<SportFieldDto>(sportField);

            return Ok(mappedsportField);
        }

        [HttpDelete("{sportFieldId}")]
        public async Task<IActionResult> DeleteSportField(Guid sportFieldId)
        {
            await _mediator.Send(new DeleteSportFieldCommand { Id = sportFieldId });
            return NoContent();
        }

    }
}
