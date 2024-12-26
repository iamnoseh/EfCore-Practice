using Domain.Entities;
using Infrastructure.ApiResponse;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controller;
[ApiController]
[Route("api/[controller]")]
public class ProductController(IProductService service):ControllerBase
{
    [HttpGet]
    public async Task<Response<List<Product>>> GetProducts()
    {
        return await service.GetProducts();
    }

    [HttpGet("[action]/{id}")]
    public async Task<Response<Product>> GetProductById(int id)
    {
        return await service.GetProductById(id);
    }

    [HttpPut]
    public async Task<Response<bool>> UpdateProduct(Product product)
    {
        return await service.UpdateProduct(product);
    }

    [HttpPost]
    public async Task<Response<bool>> AddProduct(Product product)
    {
        return await service.AddProduct(product);
    }

    [HttpDelete("[action]/{id}")]
    public async Task<Response<bool>> DeleteProduct(int id)
    {
        return await service.DeleteProduct(id);
    }
}