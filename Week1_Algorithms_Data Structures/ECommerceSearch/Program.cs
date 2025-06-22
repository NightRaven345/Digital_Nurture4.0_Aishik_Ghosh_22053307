using System;
using System.Linq;

namespace ECommerceSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            Product[] products = new Product[]
            {
                new Product { ProductId = 101, ProductName = "Laptop", Category = "Electronics" },
                new Product { ProductId = 102, ProductName = "Phone", Category = "Electronics" },
                new Product { ProductId = 103, ProductName = "Shoes", Category = "Footwear" },
                new Product { ProductId = 104, ProductName = "Watch", Category = "Accessories" },
                new Product { ProductId = 105, ProductName = "Backpack", Category = "Bags" }
            };

            Console.WriteLine("Linear Search for 'Phone':");
            var result1 = SearchEngine.LinearSearch(products, "Phone");
            Console.WriteLine(result1 != null ? result1.ToString() : "Product not found.");

            Console.WriteLine("\nBinary Search for 'Watch':");
            
            var sortedProducts = products.OrderBy(p => p.ProductName).ToArray();
            var result2 = SearchEngine.BinarySearch(sortedProducts, "Watch");
            Console.WriteLine(result2 != null ? result2.ToString() : "Product not found.");
        }
    }
}
