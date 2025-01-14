using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MediatRPractice;

[ApiController]
[Route("api/[controller]")]
public class GenericController<T> : ControllerBase where T : EntityBase
{
    private readonly IMediator _mediator;

    public GenericController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
   [HttpGet("All")]
    public async Task<ActionResult> GetEntities()
    {
        var entities = await _mediator.Send(new GetBaseEntitiesQuery<T>());
        return Ok(entities);
    }

    [HttpPost("Add")]
    public async Task<IActionResult> AddEntity([FromBody] T entity)
    {
        var id = await _mediator.Send(new AddEntityCommand<T>(entity));
        return Ok(id);
    }

    [HttpGet("Get/{id}")]
    public async Task<IActionResult> GetEntity(int id)
    {
        var entity = await _mediator.Send(new GetBaseEntityByIdQuery(id));
        if (entity == null) return NotFound();
        return Ok(entity);
    }

    [HttpPut("Update/{id}")]
    public async Task<IActionResult> UpdateEntity(int id, [FromBody] T updatedEntity)
    {
        await _mediator.Send(new UpdateEntityCommand<T>(id, updatedEntity));
        return NoContent();
    }

    [HttpDelete("Delete/{id}")]
    public async Task<IActionResult> DeleteEntity(int id)
    {
        await _mediator.Send(new DeleteEntityCommand<T>(id));
        return NoContent();
    }
}

