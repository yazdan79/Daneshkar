using System;
using System.Collections.Generic;

public interface IDiscountable
{
    void ApplyDiscount(double percentage);   
}

public class Product
{
    public string Name;
    public double Price;

    public Product(string name, double price)
    {
        Name = name;
        Price = price;
    }

    public virtual string GetProductDetails()
    {
        return "Product: " + Name + ", Price: $" + Price;
    }
}

public class Electronic : Product, IDiscountable
{
    public int WarrantyPeriod; 

    public Electronic(string name, double price, int warranty)
        : base(name, price)
    {
        WarrantyPeriod = warranty;
    }

    public override string GetProductDetails()
    {
        return "Electronic - Name: " + Name + ", Price: $" + Price +
               ", Warranty: " + WarrantyPeriod + " months";
    }

    public void ApplyDiscount(double percentage)
    {
        Price = Price - (Price * percentage / 100);
    }
}

public class Clothing : Product
{
    public string Size;
    public string Material;

    public Clothing(string name, double price, string size, string material)
        : base(name, price)
    {
        Size = size;
        Material = material;
    }

    public override string GetProductDetails()
    {
        return "Clothing - Name: " + Name + ", Price: $" + Price +
               ", Size: " + Size + ", Material: " + Material;
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Product> products = new List<Product>();

        Electronic e1 = new Electronic("Smartphone", 1000, 24);
        Clothing c1 = new Clothing("T-Shirt", 50, "M", "Cotton");

        products.Add(e1);
        products.Add(c1);

        e1.ApplyDiscount(10); 
        foreach (Product p in products)
        {
            Console.WriteLine(p.GetProductDetails());
        }

        Console.ReadLine();
    }
}
