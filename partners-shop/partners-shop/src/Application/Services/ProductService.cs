using System;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<ProductDto>> GetProductsAsync()
    {
        var products = await _unitOfWork.ProductRepository.GetAllAsync();
        return products.Select(p => new ProductDto
        {
            Id = p.Id,
            Name = p.Name,
            Description = p.Description,
            Price = p.Price,
            CategoryName = p.Category.Name
        });
    }

    public async Task<ProductDto> GetProductByIdAsync(Guid id)
    {
        var product = await _unitOfWork.ProductRepository.GetByIdAsync(id);
        if (product == null) throw new KeyNotFoundException("Product not found.");

        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            CategoryName = product.Category.Name
        };
    }

    public async Task<IEnumerable<Category>> GetCategoriesAsync() =>
        await _unitOfWork.Categories.GetAllAsync();

    public async Task AddToWishListAsync(Guid productId, Guid userId)
    {
        var wishlistItem = new WishlistItem { ProductId = productId, UserId = userId };
        await _unitOfWork.WishListsRepository.AddAsync(wishlistItem);
        await _unitOfWork.SaveChangesAsync(); // Guardar cambios como una transacción
    }

    public async Task RemoveFromWishListAsync(Guid wishlistItemId)
    {
        await _unitOfWork.WishListsRepository.DeleteAsync(wishlistItemId);
        await _unitOfWork.SaveChangesAsync(); // Guardar cambios como una transacción
    }

    public async Task<IEnumerable<ProductDto>> GetWishListAsync(Guid userId)
    {
        var wishlist = await _unitOfWork.WishListsRepository.GetByUserIdAsync(userId);
        return wishlist?.Select(p => new ProductDto
        {
            Id = p.Product.Id,
            Name = p.Product.Name,
            Description = p.Product.Description,
            Price = p.Product.Price,
            CategoryName = p.Product.Category.Name
        }) ?? Enumerable.Empty<ProductDto>();
    }
}
