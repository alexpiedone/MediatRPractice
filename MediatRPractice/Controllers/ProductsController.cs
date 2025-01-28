using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MediatRPractice;

[Route("api/products")]
[ApiController]
public class ProductsController : Controller
{
    //The IMediatR interface allows us to send messages to MediatR, which then dispatches to the relevant handlers
    private readonly IMediator _mediator;

    //a constructor that initializes a IMediatR instance:
    public ProductsController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<ActionResult> GetProducts()
    {
        var products = await _mediator.Send(new GetProductsQuery());
        return Ok(products);
    }


    [HttpPost]
    public async Task<ActionResult> AddProduct([FromBody] Product product)
    {
        var productToReturn = await _mediator.Send(new AddProductCommand(product));

        await _mediator.Publish(new ProductAddedNotification(productToReturn));

        return CreatedAtRoute("GetProductById", new { id = productToReturn.Id }, productToReturn);
    }

    [HttpGet("{id:int}", Name = "GetProductById")]
    public async Task<ActionResult> GetProductById(int id)
    {
        var product = await _mediator.Send(new GetProductByIdQuery(id));

        return Ok(product);
    }

}
