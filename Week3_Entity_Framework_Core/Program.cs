using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        using var context = new AppDbContext();

        // Ensure the symbols are displayed correctly in the console
        CultureInfo.CurrentCulture = new CultureInfo("en-IN");
        Console.OutputEncoding = Encoding.UTF8;

        // LAB 4: Inserting Initial Data into the Database
        // Ensure no duplicate data
        if (!context.Categories.Any())
        {
            var electronics = new Category { Name = "Electronics" };
            var groceries = new Category { Name = "Groceries" };

            await context.Categories.AddRangeAsync(electronics, groceries);

            var product1 = new Product { Name = "Laptop", Price = 75000, Category = electronics };
            var product2 = new Product { Name = "Rice Bag", Price = 1200, Category = groceries };

            await context.Products.AddRangeAsync(product1, product2);
            await context.SaveChangesAsync();

            Console.WriteLine("Initial data inserted.");
        }
        else
        {
            Console.WriteLine("Initial data already exists.");
        }

        // LAB 5: Retrieving Data from the Database
        // Retrieve all products
        var products = await context.Products.ToListAsync();
        Console.WriteLine("--- All Products ---");
        foreach (var p in products)
            Console.WriteLine($"{p.Name} - ₹{p.Price}");

        // Find by ID
        Console.WriteLine("\nFinding product with ID 1...");
        var laptop = await context.Products.FindAsync(1);
        Console.WriteLine($"Found: {laptop?.Name}");

        // FirstOrDefault with condition
        Console.WriteLine("\nFinding an expensive product...");
        var expensive = await context.Products.FirstOrDefaultAsync(p => p.Price > 50000);
        Console.WriteLine($"Expensive Product: {expensive?.Name}");

        // LAB 6: Updating and Deleting Records
        // Update
        Console.WriteLine("\nUpdating Laptop price...");
        var updateItem = await context.Products.FirstOrDefaultAsync(p => p.Name == "Laptop");
        if (updateItem != null)
        {
            updateItem.Price = 70000;
            await context.SaveChangesAsync();
            Console.WriteLine("Laptop price updated.");
        }

        // Delete
        Console.WriteLine("\nDeleting Rice Bag...");
        var toDelete = await context.Products.FirstOrDefaultAsync(p => p.Name == "Rice Bag");
        if (toDelete != null)
        {
            context.Products.Remove(toDelete);
            await context.SaveChangesAsync();
            Console.WriteLine("Rice Bag deleted.");
        }

        // LAB7: Writing Queries with LINQ
        // Filter and sort
        var filtered = await context.Products
            .Where(p => p.Price > 1000)
            .OrderByDescending(p => p.Price)
            .ToListAsync();

        Console.WriteLine("\nFiltered Products:");
        foreach (var p in filtered)
            Console.WriteLine($"{p.Name} - ₹{p.Price}");

        // Project to DTO
        var dtos = await context.Products
            .Select(p => new { p.Name, p.Price })
            .ToListAsync();

        Console.WriteLine("\nDTOs:");
        foreach (var d in dtos)
            Console.WriteLine($"{d.Name} → ₹{d.Price}");

    }
}
