public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetProductsAsync();
    Task<ProductDto> GetProductByIdAsync(Guid id);
    Task<IEnumerable<Category>> GetCategoriesAsync();
    Task AddToWishListAsync(Guid userId, Guid productId);
    Task RemoveFromWishListAsync(Guid productId);
    Task<IEnumerable<ProductDto>> GetWishListAsync(Guid userId);
}
