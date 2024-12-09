using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService) => _productService = productService;

    [HttpGet]
    public async Task<IActionResult> GetProducts() => Ok(await _productService.GetProductsAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(Guid id) => Ok(await _productService.GetProductByIdAsync(id));

    [HttpGet("categories")]
    public async Task<IActionResult> GetCategories() => Ok(await _productService.GetCategoriesAsync());

    [HttpPost("{id}/wishlist")]
    public async Task<IActionResult> AddToWishList(Guid id, [FromHeader] Guid userId)
    {
        await _productService.AddToWishListAsync(userId, id);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveFromWishList(Guid id)
    {
        await _productService.RemoveFromWishListAsync(id);
        return NoContent();
    }

    [HttpGet("wishlist")]
    public async Task<IActionResult> GetWishList([FromHeader] Guid userId) => Ok(await _productService.GetWishListAsync(userId));
}
