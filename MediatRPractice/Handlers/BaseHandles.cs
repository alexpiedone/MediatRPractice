using Domain;
using MediatR;

namespace MediatRPractice;


public class AddEntityHandler<T> : IRequestHandler<AddEntityCommand<T>, T> where T : EntityBase
{
    private readonly PracticeDataStore _dataStore;

    public AddEntityHandler(PracticeDataStore dataStore)
    {
        _dataStore = dataStore;
    }

    public async Task<T> Handle(AddEntityCommand<T> request, CancellationToken cancellationToken)
    {
        await _dataStore.AddEntity(request.Entity);
        return request.Entity;
    }
}

//public class GetEntityByIdHandler<T> : IRequestHandler<GetBaseEntityByIdQuery, T?> where T : EntityBase
//{
//    private readonly PracticeDataStore _dataStore;

//    public GetEntityByIdHandler(PracticeDataStore dataStore)
//    {
//        _dataStore = dataStore;
//    }

//    public async Task<T?> Handle(GetBaseEntityByIdQuery<T> request, CancellationToken cancellationToken)
//    {
//        return await _dataStore.GetEntityById<T>(request.Id);
//    }
//}


public class GetBaseEntitiesHandler<T> : IRequestHandler<GetBaseEntitiesQuery<T>, IEnumerable<T>> where T : EntityBase
{
    private readonly PracticeDataStore _dataStore;

    public GetBaseEntitiesHandler(PracticeDataStore dataStore)
    {
        _dataStore = dataStore;
    }

    public async Task<IEnumerable<T>> Handle(GetBaseEntitiesQuery<T> request, CancellationToken cancellationToken)
    {
        return await _dataStore.GetAllEntities<T>();
    }
}







