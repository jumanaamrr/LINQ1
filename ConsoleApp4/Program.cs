using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductQueriesDemo
{
    // ---------- Model ----------
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public bool Discontinued { get; set; }
    }

    internal class Program
    {
        // ---------- Seed data (in-memory "ProductList") ----------
        private static readonly List<Product> ProductList = new List<Product>
        {
            new Product { ProductID = 1,  ProductName = "Ikura",          Category = "Seafood",     UnitPrice = 31.00m, UnitsInStock = 31 },
            new Product { ProductID = 2,  ProductName = "Konbu",         Category = "Seafood",     UnitPrice = 6.00m,  UnitsInStock = 24 },
            new Product { ProductID = 3,  ProductName = "Carnarvon Tigers", Category = "Seafood",  UnitPrice = 62.50m, UnitsInStock = 42 },
            new Product { ProductID = 4,  ProductName = "Boston Crab Meat", Category = "Seafood",  UnitPrice = 18.40m, UnitsInStock = 123 },
            new Product { ProductID = 5,  ProductName = "Nord-Ost Matjeshering", Category = "Seafood", UnitPrice = 25.89m, UnitsInStock = 10 },
            new Product { ProductID = 6,  ProductName = "Chai",           Category = "Beverages",   UnitPrice = 18.00m, UnitsInStock = 39 },
            new Product { ProductID = 7,  ProductName = "Chang",          Category = "Beverages",   UnitPrice = 19.00m, UnitsInStock = 17 },
            new Product { ProductID = 8,  ProductName = "Aniseed Syrup",  Category = "Condiments",  UnitPrice = 10.00m, UnitsInStock = 13 },
            new Product { ProductID = 9,  ProductName = "Chef Anton's Cajun Seasoning", Category = "Condiments", UnitPrice = 22.00m, UnitsInStock = 53 },
            new Product { ProductID = 10, ProductName = "Grandma's Boysenberry Spread",  Category = "Condiments", UnitPrice = 25.00m, UnitsInStock = 0  },
            new Product { ProductID = 11, ProductName = "Sir Rodney's Marmalade",        Category = "Confections", UnitPrice = 81.00m, UnitsInStock = 40 },
            new Product { ProductID = 12, ProductName = "Pavlova",        Category = "Confections", UnitPrice = 17.45m, UnitsInStock = 29 },
            new Product { ProductID = 13, ProductName = "Alice Mutton",   Category = "Meat/Poultry", UnitPrice = 39.00m, UnitsInStock = 0  },
            new Product { ProductID = 14, ProductName = "Mishi Kobe Niku", Category = "Meat/Poultry", UnitPrice = 97.00m, UnitsInStock = 29 },
        };

        private static void Main()
        {
            // ============================================================
            // 1. Get all products from the "Seafood" category.
            //    Print each product's name and price.
            // ============================================================
            Console.WriteLine("=== 1. Seafood products (Name, Price) ===");
            var seafood = ProductList.Where(p => p.Category == "Seafood");
            foreach (var p in seafood)
                Console.WriteLine($"{p.ProductName} - {p.UnitPrice:C}");

            Console.WriteLine();

            // ============================================================
            // 2. Get a list of only the product names from ProductList.
            //    Print each name.
            // ============================================================
            Console.WriteLine("=== 2. All product names ===");
            var names = ProductList.Select(p => p.ProductName);
            foreach (var n in names)
                Console.WriteLine(n);

            Console.WriteLine();

            // ============================================================
            // 3. Get all products where UnitPrice is between 10 and 30.
            // ============================================================
            Console.WriteLine("=== 3. Products with UnitPrice between 10 and 30 ===");
            var midPriced = ProductList.Where(p => p.UnitPrice >= 10m && p.UnitPrice <= 30m);
            foreach (var p in midPriced)
                Console.WriteLine($"{p.ProductName} - {p.UnitPrice:C}");

            Console.WriteLine();

            // ============================================================
            // 4. Get all products that are in stock (UnitsInStock > 0)
            //    AND belong to the "Condiments" category.
            // ============================================================
            Console.WriteLine("=== 4. In-stock Condiments ===");
            var condimentsInStock = ProductList
                .Where(p => p.UnitsInStock > 0 && p.Category == "Condiments");
            foreach (var p in condimentsInStock)
                Console.WriteLine($"{p.ProductName} - {p.UnitsInStock} in stock");

            Console.WriteLine();

            // ============================================================
            // 5. Create a new anonymous type with three properties:
            //    Name, Price, StockStatus ("Available" / "Out of Stock").
            //    Print the result.
            // ============================================================
            Console.WriteLine("=== 5. Anonymous type projection (Name, Price, StockStatus) ===");
            var projected = ProductList.Select(p => new
            {
                Name = p.ProductName,
                Price = p.UnitPrice,
                StockStatus = p.UnitsInStock > 0 ? "Available" : "Out of Stock"
            });

            foreach (var item in projected)
                Console.WriteLine($"{item.Name,-35} | {item.Price,8:C} | {item.StockStatus}");
        }
    }
}