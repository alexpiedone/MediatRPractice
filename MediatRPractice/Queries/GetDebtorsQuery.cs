using Domain;
using MediatR;

namespace MediatRPractice;

public record GetDebtorsQuery() : IRequest<IEnumerable<Debtor>>;

