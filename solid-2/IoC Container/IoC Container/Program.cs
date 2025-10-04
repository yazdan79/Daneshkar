using System;
using Microsoft.Extensions.DependencyInjection;


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
    private IProductDataSource dataSource;  

    public ProductDisplay(IProductDataSource dataSource)
    {
        this.dataSource = dataSource;
    }

    public void ShowProducts()
    {
        dataSource.ShowProducts();
    }
}

class Program
{
    static void Main(string[] args)
    {
        var services = new ServiceCollection();

        Console.WriteLine("Enter a type of data source (Database / API / File):");
        string input = Console.ReadLine()?.ToLower();

        if (input == "database")
            services.AddTransient<IProductDataSource, DatabaseDataSource>();
        else if (input == "api")
            services.AddTransient<IProductDataSource, APIDataSource>();
        else if (input == "file")
            services.AddTransient<IProductDataSource, FileDataSource>();
        else
        {
            Console.WriteLine("type of data source is not valid!");
            return;
        }

        services.AddTransient<ProductDisplay>();

        var serviceProvider = services.BuildServiceProvider();

        var display = serviceProvider.GetService<ProductDisplay>();
        display.ShowProducts();
    }
}