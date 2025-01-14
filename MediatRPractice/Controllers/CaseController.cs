using Domain;
using MediatR;
using Microsoft.AspNetCore.Components;

namespace MediatRPractice;

[Route("api/case")]
public class CaseController : GenericController<Case>
{
    public CaseController(IMediator mediator) : base(mediator) { }
}
