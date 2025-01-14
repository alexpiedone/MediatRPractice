using Domain;
using MediatR;

namespace MediatRPractice
{
    public record AddEntityCommand<T>(T Entity) : IRequest<T>;
    public record UpdateEntityCommand<T>(int Id, T UpdatedEntity) : IRequest;
    public record DeleteEntityCommand<T>(int Id) : IRequest;

}
