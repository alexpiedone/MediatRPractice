namespace Domain;

public class PracticeDataStore
{
    private static List<Product> _products;
    private static List<Debtor> _debtors;
    private static List<Case> _cases;
    private static List<EntityBase> _entities;
    public PracticeDataStore()
    {
        _products = new List<Product>
        {
            new() { Id = 1, Name = "Test Product 1" },
            new() { Id = 2, Name = "Test Product 2" },
            new() { Id = 3, Name = "Test Product 3" }
        };
        
        _debtors = new List<Debtor>
        {
            new() { Id = 1, Name = "Test debtor 1" },
            new() { Id = 2, Name = "Test debtor 2" },
            new() { Id = 3, Name = "Test debtor 3" }
        };
        _cases = new List<Case>
        {
            new() { Id = 1, Title = "Test case 1" },
            new() { Id = 2, Title = "Test case 2" },
            new() { Id = 3, Title = "Test case 3" }
        };
    }

    #region Product
    public async Task AddProduct(Product product)
    {
        _products.Add(product);
        await Task.CompletedTask;
    }
    public async Task<IEnumerable<Product>> GetAllProducts() => await Task.FromResult(_products);

    public async Task<Product> GetProductById(int id) =>
        await Task.FromResult(_products.Single(p => p.Id == id));

    public async Task EventOccured(Product product, string evt)
    {
        _products.Single(p => p.Id == product.Id).Name = $"{product.Name} evt: {evt}";
        await Task.CompletedTask;
    }
    #endregion

    #region Debtor
    public async Task AddDebtor(Debtor debtor)
    {
        _debtors.Add(debtor);
        await Task.CompletedTask;
    }

    public async Task<Debtor> GetDebtorById(int id) =>
       await Task.FromResult(_debtors.Single(p => p.Id == id));


    public async Task<IEnumerable<Debtor>> GetAllDebtors() => await Task.FromResult(_debtors);
    public async Task<IEnumerable<Case>> GetAllcases() => await Task.FromResult(_cases);

    public async Task EventOccured(Debtor debtor, string evt)
    {
        _debtors.Single(p => p.Id == debtor.Id).Name = $"{debtor.Name} evt: {evt}";
        await Task.CompletedTask;
    }
    #endregion

    #region BaseEntity
    public async Task AddEntity<T>(T entity) where T : EntityBase
    {
        if (typeof(T) == typeof(Product))
        {
            await AddProduct(entity as Product);
        }
        else if (typeof(T) == typeof(Debtor))
        {
            await AddDebtor(entity as Debtor);
        }
        else
        {
            throw new NotSupportedException($"Entity type {typeof(T)} is not supported.");
        }
    }

    public async Task<IEnumerable<T>> GetAllEntities<T>() where T : EntityBase
    {
        if (typeof(T) == typeof(Product))
        {
            return (await GetAllProducts()) as IEnumerable<T>;
        }
        else if (typeof(T) == typeof(Debtor))
        {
            return (await GetAllDebtors()) as IEnumerable<T>;
        }
         else if (typeof(T) == typeof(Case))
        {
            return (await GetAllcases()) as IEnumerable<T>;
        }

        throw new NotSupportedException($"Entity type {typeof(T)} is not supported.");
    }

    public async Task<T> GetEntityById<T>(int id) where T : EntityBase
    {
        if (typeof(T) == typeof(Product))
        {
            return (await GetProductById(id)) as T;
        }
        else if (typeof(T) == typeof(Debtor))
        {
            return (await GetDebtorById(id)) as T;
        }

        throw new NotSupportedException($"Entity type {typeof(T)} is not supported.");
    }
    #endregion

}