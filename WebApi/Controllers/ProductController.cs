using Domain.Models;
using Infrastructure.ApiResponse;
using Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ProductController(IProductService productService):ControllerBase
{
    [HttpGet("GetAllProducts")]
    public async Task<Response<List<Product>>> GetAll()
    {
        var response = await productService.GetAll();
        return response;
    }
    [HttpGet("GetProductByPhone")]
    public async Task<Response<Product>> GetProductById(int id)
    {
        return productService.GetById(id).Result;
    }

    [HttpPost("AddProduct")]
    public async Task<Response<bool>> Create(Product product)
    {
        var response = await productService.Create(product);
        return response;
    }

    [HttpPut("UpdateProduct")]
    public async Task<Response<bool>> UpdateProduct(Product product)
    {
        var response = await productService.Update(product);
        return response;
    }

    [HttpDelete("DeleteProduct")]
    public async Task<Response<bool>> Delete(int id)
    {
        var response = await productService.Delete(id);
        return response;
    }
    [HttpGet("getSave")]
    public async Task<Response<List<Product>>> GetSave()
    {
        var response = await productService.GetSave();
        return response;
    }
}