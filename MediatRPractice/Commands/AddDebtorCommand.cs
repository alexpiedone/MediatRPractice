using Domain;
using MediatR;

namespace MediatRPractice;

public record AddDebtorCommand(Debtor Product) : IRequest<Debtor>;

