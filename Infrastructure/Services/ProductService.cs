using System.Net;
using Domain.Entities;
using Infrastructure.ApiResponse;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class ProductService(DataContext _context): IProductService
{
    public async Task<Response<List<Product>>> GetProducts()
    {
        var effect =await _context.Products.ToListAsync();
        return new Response<List<Product>>(effect);
    }

    public async Task<Response<Product>> GetProductById(int id)
    {
        var effect = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        return new Response<Product>(effect);
        
    }

    public async Task<Response<bool>> AddProduct(Product product)
    {
        var effect =await _context.Products.AddAsync(product);
        return effect == null
            ? new Response<bool>(HttpStatusCode.InternalServerError, "Product not added")
            : new Response<bool>(true);
    }

    public async Task<Response<bool>> UpdateProduct(Product product)
    {
        var p = await _context.Products.FirstOrDefaultAsync(g => g.Id == product.Id);

        if (p == null)
        {
            return new Response<bool>(HttpStatusCode.NotFound, "Product not found");
        }
        p.Name = product.Name;
        p.Category = product.Category;
        p.Price = product.Price;
        var effectedRows = await _context.SaveChangesAsync();
        return effectedRows == 0
            ? new Response<bool>(HttpStatusCode.InternalServerError, "Product not updated")
            : new Response<bool>(true);
        
    }

    public async Task<Response<bool>> DeleteProduct(int id)
    {
        var p = await _context.Products.FirstOrDefaultAsync(g => g.Id == id);

        if (p == null)
        {
            return new Response<bool>(HttpStatusCode.NotFound, "Product not found");
        }
        _context.Products.Remove(p);
        var effectedRows = await _context.SaveChangesAsync();
        return effectedRows == 0
            ? new Response<bool>(HttpStatusCode.InternalServerError, "Product not deleted")
            : new Response<bool>(true);
    }
}