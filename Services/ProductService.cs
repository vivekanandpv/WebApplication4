using Microsoft.EntityFrameworkCore;
using WebApplication4.DAL;
using WebApplication4.Models;
using WebApplication4.ViewModels;

namespace WebApplication4.Services;

public class ProductService : IProductService
{
    private readonly ProductCatalogContext _context;

    public ProductService(ProductCatalogContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ProductViewModel>> GetAllAsync()
    {
        return await _context.Products
            .Select(p => new ProductViewModel
            {
                ProductId = p.ProductId,
                Name = p.Name,
                BasePrice = p.BasePrice,
                TaxRate = p.TaxRate,
                Description = p.Description
            })
            .ToListAsync();
    }

    public async Task<ProductViewModel> GetByIdAsync(int id)
    {
        return ToViewModel(await FromId(id));
    }

    public async Task<ProductViewModel> CreateAsync(ProductCreateViewModel product)
    {
        var p = ToEntity(product);
        await _context.AddAsync(p);
        await _context.SaveChangesAsync();
        return ToViewModel(p);
    }

    public async Task<ProductViewModel> UpdateAsync(int id, ProductUpdateViewModel product)
    {
        var p = await FromId(id);

        p.Name = product.Name;
        p.Description = product.Description;

        await _context.SaveChangesAsync();

        return ToViewModel(p);
    }

    public async Task DeleteAsync(int id)
    {
        var p = await FromId(id);
        _context.Products.Remove(p);
        await _context.SaveChangesAsync();
    }

    private ProductViewModel ToViewModel(Product p)
    {
        return new ProductViewModel
        {
            ProductId = p.ProductId,
            Name = p.Name,
            BasePrice = p.BasePrice,
            TaxRate = p.TaxRate,
            Description = p.Description
        };
    }

    private Product ToEntity(ProductCreateViewModel p)
    {
        return new Product
        {
            Name = p.Name,
            BasePrice = p.BasePrice,
            TaxRate = p.TaxRate,
            Description = p.Description
        };
    }

    private async Task<Product> FromId(int id)
    {
        return await _context.Products.FirstAsync(p => p.ProductId == id);
    }
}