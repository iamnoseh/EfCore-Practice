using Domain.Entities;
using Infrastructure.ApiResponse;

namespace Infrastructure.Services;

public interface IProductService
{
    Task<Response<List<Product>>> GetProducts();
    Task<Response<Product>> GetProductById(int id);
    Task<Response<bool>> AddProduct(Product product);
    Task<Response<bool>> UpdateProduct(Product product);
    Task<Response<bool>> DeleteProduct(int id);
}