using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MediatRPractice;

public class DebtorsController : Controller
{
    private readonly IMediator _mediator;
    public DebtorsController(IMediator mediator) => _mediator = mediator;
    [HttpPost]
    public async Task<IActionResult> AddDebtor([FromBody] Debtor debtor)
    {
        var result = await _mediator.Send(new AddDebtorCommand(debtor));
        return Ok(result);
    }

    
    [HttpGet]
    public async Task<ActionResult> GetDebtors()
    {
        var debtors = await _mediator.Send(new GetProductsQuery());
        return Ok(debtors);
    }

}
