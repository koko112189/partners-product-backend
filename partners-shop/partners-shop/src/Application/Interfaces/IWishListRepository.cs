
namespace Application.Interfaces;

public interface IWishlistRepository
{
    Task<IEnumerable<WishlistItem>> GetByUserIdAsync(Guid userId);
    Task AddAsync(WishlistItem wishlistItem);
    Task DeleteAsync(Guid wishlistItemId);
}
