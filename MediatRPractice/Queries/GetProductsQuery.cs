using Domain;
using MediatR;

namespace MediatRPractice;

public record GetProductsQuery() : IRequest<IEnumerable<Product>>;
