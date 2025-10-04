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

class DataSourceFactory
{
    public static IProductDataSource GetDataSource(string sourceType)
    {
        switch (sourceType.ToLower())
        {
            case "database":
                return new DatabaseDataSource();
            case "api":
                return new APIDataSource();
            case "file":
                return new FileDataSource();
            default:
                throw new ArgumentException("Type of data source is not valid!");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("please Enter Type of Data source: (Database / API / File)");
        string input = Console.ReadLine();

        try
        {
            IProductDataSource dataSource = DataSourceFactory.GetDataSource(input);
            ProductDisplay display = new ProductDisplay(dataSource);
            display.ShowProducts();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}