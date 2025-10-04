using System;

interface IProductDataSource
{
    void ShowProducts();
}

class DatabaseDataSource : IProductDataSource
{
    public void ShowProducts()
    {
        Console.WriteLine("Laptop - $1200");
        Console.WriteLine("Phone - $800");
    }
}


class APIDataSource : IProductDataSource
{
    public void ShowProducts()
    {
        Console.WriteLine("Tablet - $500");
        Console.WriteLine("Monitor - $300");
    }
}

class FileDataSource : IProductDataSource
{
    public void ShowProducts()
    {
        Console.WriteLine("Keyboard - $50");
        Console.WriteLine("Mouse - $30");
    }
}

class ProductDisplay
{
    private IProductDataSource _dataSource;

    public ProductDisplay(IProductDataSource dataSource)
    {
        _dataSource = dataSource;
    }

    public void ShowProducts()
    {
        _dataSource.ShowProducts();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("products from Database:");
        ProductDisplay display1 = new ProductDisplay(new DatabaseDataSource());
        display1.ShowProducts();

        Console.WriteLine("products from  API:");
        ProductDisplay display2 = new ProductDisplay(new APIDataSource());
        display2.ShowProducts();

        Console.WriteLine("products from file:");
        ProductDisplay display3 = new ProductDisplay(new FileDataSource());
        display3.ShowProducts();
    }
}