using Application.SportFields.Commands.CreateSportField;
using Application.SportFields.Commands.DeleteSportField;
using Application.SportFields.Commands.UpdateSportField;
using Application.SportFields.Queries.GetAllSportFields;
using Application.SportFields.Queries.GetSportFieldById;
using AutoMapper;
using Domain;
using FieldForYou.Api.Dto;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportFieldScheduler.Application.Dto;

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

        [HttpPost]
        public async Task<IActionResult> CreateSportField(SportFieldPostDto sportfield)
        {

            var command = _mapper.Map<SportFieldPostDto, CreateSportFieldCommand>(sportfield);
            var created = await _mediator.Send(command);
            var dto = _mapper.Map<SportField, SportFieldDto>(created);
            return CreatedAtAction(nameof(GetSportField), new { id = created.Id }, dto);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllSportFields()
        {
            var sportFieldsList = await _mediator.Send(new GetAllSportFieldsQuery());
            var mappedsportFieldList = _mapper.Map<List<SportFieldDto>>(sportFieldsList);

            return Ok(mappedsportFieldList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSportField(Guid id)
        {
            var sportField = await _mediator.Send(new GetSportFieldByIdQuery { Id = id});
            var mappedsportField = _mapper.Map<SportField, SportFieldDto>(sportField);

            return Ok(mappedsportField);
        }

        [HttpDelete("{sportFieldId}")]
        public async Task<IActionResult> DeleteSportField(Guid sportFieldId)
        {
            await _mediator.Send(new DeleteSportFieldCommand { Id = sportFieldId });
            return NoContent();
        }

        [HttpPatch("{sportFiledId}")]
        public async Task<IActionResult> UpdateSportField(Guid sportFiledId, SportFieldDto sportFieldDto)
        {
            var updateField = new UpdateSportFieldCommand
            {
              Category = sportFieldDto.Category,
              Address = sportFieldDto.Address,
              City = sportFieldDto.City,
              Description = sportFieldDto.Description,
              Name = sportFieldDto.Name,
              PricePerHour = sportFieldDto.PricePerHour,
              Img = sportFieldDto.Img,
              Id = sportFiledId
             
            };
            var x = await _mediator.Send(updateField);
            return NoContent();
        }


    }
}
