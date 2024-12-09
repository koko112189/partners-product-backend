using Application.Interfaces;
using Infrastructure.Persistence.Repositories;

public interface IUnitOfWork : IDisposable
{
    IProductRepository ProductRepository { get; }
    IRepository<Category> Categories { get; }
    IWishlistRepository WishListsRepository { get; }
    Task<int> SaveChangesAsync();
}

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
        ProductRepository = new ProductRepository(_context);
        Categories = new Repository<Category>(_context);
        WishListsRepository = new WishlistRepository(_context);
    }

    public IProductRepository ProductRepository { get; }
    public IRepository<Category> Categories { get; }
    public IWishlistRepository WishListsRepository { get; }


    public void Dispose()
    {
        _context.Dispose();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
