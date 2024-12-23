namespace Domain.Models;

public class Product
{
// - Настройте PostgreSQL и создайте таблицу `Products` с полями:  
// - `Id` (идентификатор, первичный ключ).  
// - `Name` (название продукта).  
// - `Description` (описание продукта).  
// - `Price` (цена, decimal).  
// - `StockQuantity` (количество на складе).  
// - `CategoryName` (категория продукта).  
// - `CreatedDate` (дата создания).   
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public string CategoryName { get; set; }
    public DateTime CreatedDate { get; set; }
}