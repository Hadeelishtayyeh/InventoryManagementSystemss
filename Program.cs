using System;
using InventorySystem.Models;

class Program
{
    static Inventory inventory = new Inventory();

    static void Main()
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n=== Inventory Management System ===");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. View All Products");
            Console.WriteLine("3. Edit Product");
            Console.WriteLine("4. Delete Product");
            Console.WriteLine("5. Search Product");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    AddProduct();
                    break;
                case "2":
                    inventory.ViewAllProducts();
                    break;
                case "3":
                    EditProduct();
                    break;
                case "4":
                    DeleteProduct();
                    break;
                case "5":
                    SearchProduct();
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }

        Console.WriteLine("Exiting the program...");
    }

    static void AddProduct()
    {
        Console.Write("Product Name: ");
        string name = Console.ReadLine();

        Console.Write("Price: ");
        decimal price = decimal.Parse(Console.ReadLine());

        Console.Write("Quantity: ");
        int quantity = int.Parse(Console.ReadLine());

        inventory.AddProduct(new Product(name, price, quantity));
        Console.WriteLine("Product added.");
    }

    static void EditProduct()
    {
        Console.Write("Enter the product name to edit: ");
        string name = Console.ReadLine();

        var product = inventory.SearchProduct(name);
        if (product != null)
        {
            Console.Write("New Name: ");
            string newName = Console.ReadLine();

            Console.Write("New Price: ");
            decimal newPrice = decimal.Parse(Console.ReadLine());

            Console.Write("New Quantity: ");
            int newQuantity = int.Parse(Console.ReadLine());

            inventory.EditProduct(name, newName, newPrice, newQuantity);
            Console.WriteLine("Product updated.");
        }
        else
        {
            Console.WriteLine("Product not found.");
        }
    }

    static void DeleteProduct()
    {
        Console.Write("Enter the product name to delete: ");
        string name = Console.ReadLine();

        if (inventory.DeleteProduct(name))
            Console.WriteLine("Product deleted.");
        else
            Console.WriteLine("Product not found.");
    }

    static void SearchProduct()
    {
        Console.Write("Enter the product name to search: ");
        string name = Console.ReadLine();

        var product = inventory.SearchProduct(name);
        if (product != null)
            Console.WriteLine(product);
        else
            Console.WriteLine("Product not found.");
    }
}
