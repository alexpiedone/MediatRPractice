using Domain;
using MediatR;

namespace MediatRPractice;

public class GetProductsHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
{
    private readonly PracticeDataStore _fakeDataStore;

    public GetProductsHandler(PracticeDataStore fakeDataStore) => _fakeDataStore = fakeDataStore;

    public async Task<IEnumerable<Product>> Handle(GetProductsQuery request,
        CancellationToken cancellationToken) => await _fakeDataStore.GetAllProducts();
}
