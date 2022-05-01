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
        public async Task<IActionResult> CreateSportField(SportFieldDto sportfield)
        {

            var sport_field = _mapper.Map<SportField>(sportfield);
            var command = new CreateSportFieldCommand
            {
                Address = sport_field.Address,
                Category = sport_field.Category,
                City = sport_field.City,
                Img = sport_field.Img,
                PricePerHour = sport_field.PricePerHour,
                Description = sport_field.Description,
                Name = sport_field.Name
            };
            var resultSportField = await _mediator.Send(command);
            return Created($"/api/[controller]/{resultSportField.Id}", null);
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
