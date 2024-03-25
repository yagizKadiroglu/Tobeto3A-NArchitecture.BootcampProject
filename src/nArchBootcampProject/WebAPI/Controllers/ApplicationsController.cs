using Application.Features.Applications.Commands.Create;
using Application.Features.Applications.Commands.Delete;
using Application.Features.Applications.Commands.Update;
using Application.Features.Applications.Queries.GetById;
using Application.Features.Applications.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApplicationsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateApplicationCommand createApplicationCommand)
    {
        CreatedApplicationResponse response = await Mediator.Send(createApplicationCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateApplicationCommand updateApplicationCommand)
    {
        UpdatedApplicationResponse response = await Mediator.Send(updateApplicationCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedApplicationResponse response = await Mediator.Send(new DeleteApplicationCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdApplicationResponse response = await Mediator.Send(new GetByIdApplicationQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListApplicationQuery getListApplicationQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListApplicationListItemDto> response = await Mediator.Send(getListApplicationQuery);
        return Ok(response);
    }
}