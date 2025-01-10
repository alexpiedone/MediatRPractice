using Domain;
using MediatR;

namespace MediatRPractice;

public record GetProductByIdQuery(int Id) : IRequest<Product>;
