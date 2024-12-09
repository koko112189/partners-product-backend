

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product> GetByIdAsync(Guid id);
    Task<IEnumerable<Category>> GetAllCategoriesAsync();
}
