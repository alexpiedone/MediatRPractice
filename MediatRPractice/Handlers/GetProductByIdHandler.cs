using Domain;
using MediatR;

namespace MediatRPractice;

public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
{
    private readonly PracticeDataStore _fakeDataStore;

    public GetProductByIdHandler(PracticeDataStore fakeDataStore) => _fakeDataStore = fakeDataStore;

    public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken) =>
        await _fakeDataStore.GetProductById(request.Id);

}
