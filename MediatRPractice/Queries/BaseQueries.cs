using Domain;
using MediatR;

namespace MediatRPractice;



public record GetBaseEntityByIdQuery(int Id) : IRequest<EntityBase>;

public record GetBaseEntitiesQuery<T>() : IRequest<IEnumerable<T>> where T : EntityBase;

