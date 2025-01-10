using Domain;
using MediatR;

namespace MediatRPractice;


public record AddProductCommand(Product Product) : IRequest<Product>;
