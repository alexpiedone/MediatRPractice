using Domain;
using MediatR;

namespace MediatRPractice;

public class AddProductHandler : IRequestHandler<AddProductCommand, Product>
{
    private readonly PracticeDataStore _fakeDataStore;

    public AddProductHandler(PracticeDataStore fakeDataStore) => _fakeDataStore = fakeDataStore;

    public async Task<Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        await _fakeDataStore.AddProduct(request.Product);
            
        return request.Product; 
    }
}
