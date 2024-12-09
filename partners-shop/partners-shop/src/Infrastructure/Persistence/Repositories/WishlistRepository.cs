using Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class WishlistRepository : IWishlistRepository
{
    private readonly AppDbContext _context;

    public WishlistRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<WishlistItem>> GetByUserIdAsync(Guid userId)
    {
        return await _context.WishLists
            .Include(w => w.Product) // Incluimos los detalles del producto
            .Where(w => w.UserId == userId)
            .ToListAsync();
    }

    public async Task AddAsync(WishlistItem wishlistItem)
    {
        _context.WishLists.Add(wishlistItem);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid wishlistItemId)
    {
        var wishlistItem = await _context.WishLists.FindAsync(wishlistItemId);
        if (wishlistItem != null)
        {
            _context.WishLists.Remove(wishlistItem);
            await _context.SaveChangesAsync();
        }
    }
}
