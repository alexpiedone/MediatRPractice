using Domain;
using MediatR;

namespace MediatRPractice;

public record ProductAddedNotification(Product Product) : INotification;
