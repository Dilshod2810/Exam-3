using Domain.Models;
using Infrastructure.ApiResponse;

namespace Infrastructure.Service;

public interface IProductService
{
    Task<Response<List<Product>>> GetAll();
    Task<Response<Product>> GetById(int id);
    Task<Response<bool>> Create(Product product);
    Task<Response<bool>> Update(Product product);
    Task<Response<bool>> Delete(int id);
    Task<Response<List<Product>>> GetSave();
}