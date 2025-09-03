using System;
using System.Collections.Generic;

namespace InventorySystem.Models
{
    public class Inventory
    {
        private List<Product> products = new List<Product>();

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public void ViewAllProducts()
        {
            if (products.Count == 0)
            {
                Console.WriteLine("Inventory is empty.");
                return;
            }

            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
        }

        public Product SearchProduct(string name)
        {
            return products.Find(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public bool DeleteProduct(string name)
        {
            var product = SearchProduct(name);
            if (product != null)
            {
                products.Remove(product);
                return true;
            }
            return false;
        }

        public bool EditProduct(string name, string newName, decimal newPrice, int newQuantity)
        {
            var product = SearchProduct(name);
            if (product != null)
            {
                product.Name = newName;
                product.Price = newPrice;
                product.Quantity = newQuantity;
                return true;
            }
            return false;
        }
    }
}
