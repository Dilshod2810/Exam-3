using System.Drawing;
using System.Net;
using Dapper;
using Domain.Models;
using Infrastructure.ApiResponse;
using Infrastructure.DataContext;

namespace Infrastructure.Service;

public class ProductService(DapperContext context):IProductService
{
    public async Task<Response<List<Product>>> GetAll()
    {
        string sql = "select * from products;";
        var res = await context.Connection().QueryAsync<Product>(sql);
        return new Response<List<Product>>(res.ToList());
    }

    public async Task<Response<Product>> GetById(int id)
    {
        string sql = "select * from products where id=@Id";
        var res = await context.Connection().QuerySingleOrDefaultAsync<Product>(sql, new { Id = id });
        return res == null
            ? new Response<Product>(HttpStatusCode.NotFound, "Product not found")
            : new Response<Product>(HttpStatusCode.OK, "Founded");
    }

    public async Task<Response<bool>> Create(Product product)
    {
        string sql = "insert into products (name, description, price, stockquantity, categoryname, createddate) values(@Name, @Description, @Price, @StockQuantity, @CategoryName, @CreatedDate)";
        var res = await context.Connection().ExecuteAsync(sql, product);
        return res > 0
            ? new Response<bool>(HttpStatusCode.Created, "Success")
            : new Response<bool>(HttpStatusCode.BadRequest, "Failed to create product");
    }

    public async Task<Response<bool>> Update(Product product)
    {
        string sql="UPDATE products set name=@Name, description=@Description, price=@Price, stockquantity=@StockQuantity, categoryname=@CategoryName, createddate=@CreatedDate WHERE id=@Id";
        var res = await context.Connection().ExecuteAsync(sql, product);
        return res > 0
            ? new Response<bool>(HttpStatusCode.OK, "Success")
            : new Response<bool>(HttpStatusCode.NotFound, "Not found");
    }

    public async Task<Response<bool>> Delete(int id)
    {
        string sql = @"DELETE FROM products WHERE id=@Id";
        var res = GetById(id).Result.Data;
        if (res == null)
        {
            return new Response<bool>(HttpStatusCode.NotFound, "Not found");
        }

        var deleted = await context.Connection().ExecuteAsync(sql, new { Id = id });
        return deleted > 0
            ? new Response<bool>(HttpStatusCode.OK, "Deleted successfully")
            : new Response<bool>(HttpStatusCode.NotFound, "Not found");
    }

    public async Task<Response<List<Product>>> GetSave()
    {
        string sql = "select * from products;";
         var res = await context.Connection().QueryAsync<Product>(sql);
    //     return new Response<List<Product>>(res.ToList());
        string path = @"C:\Users\Admin\Desktop\Exam3\Infrastructure\Migration\Migration.sql";
        File.WriteAllText(path, res.ToString());
        return new Response<List<Product>>(res.ToList());

    }
    
    
    
    
    
}