using Domain;
using MediatR;

namespace MediatRPractice;

public class EmailHandler : INotificationHandler<ProductAddedNotification>
{
    private readonly PracticeDataStore _fakeDataStore;

    public EmailHandler(PracticeDataStore fakeDataStore) => _fakeDataStore = fakeDataStore;

    public async Task Handle(ProductAddedNotification notification, CancellationToken cancellationToken)
    {
        await _fakeDataStore.EventOccured(notification.Product, "Email sent");
        await Task.CompletedTask;
    }
}

public class CacheInvalidationHandler : INotificationHandler<ProductAddedNotification>
{
    private readonly PracticeDataStore _fakeDataStore;

    public CacheInvalidationHandler(PracticeDataStore fakeDataStore) => _fakeDataStore = fakeDataStore;

    public async Task Handle(ProductAddedNotification notification, CancellationToken cancellationToken)
    {
        await _fakeDataStore.EventOccured(notification.Product, "Cache Invalidated");
        await Task.CompletedTask;
    }
}
