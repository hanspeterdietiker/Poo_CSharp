﻿using Lambda_CSharp2.entities;

namespace Lambda_CSharp2;

internal class Program
{
    static void Print<T>(string message, IEnumerable<T> collection)
    {
        Console.WriteLine(message);
        foreach (T obj in collection)
        {
            Console.WriteLine(obj);
        }
    }

    static void Main(string[] args)
    {
        Category c1 = new Category() { Id = 1, Name = "Tools", Tier = 2 };
        Category c2 = new Category() { Id = 2, Name = "Computers", Tier = 1 };
        Category c3 = new Category() { Id = 3, Name = "Eletronics", Tier = 1 };

        List<Product> products = new List<Product>()
        {
            new Product() { Id = 1, Name = "Computers", Price = 1100.0, Category = c3 },
            new Product() { Id = 2, Name = "Hammer", Price = 90.0, Category = c1 },
            new Product() { Id = 3, Name = "Tv", Price = 1700.0, Category = c2 },
            new Product() { Id = 4, Name = "Notebook", Price = 1300.0, Category = c3 },
            new Product() { Id = 5, Name = "Saw", Price = 80.0, Category = c1 },
            new Product() { Id = 6, Name = "Tablet", Price = 700.0, Category = c3 },
            new Product() { Id = 7, Name = "CellPhone", Price = 700.0, Category = c3 }
        };

        /*var r1 = products.
            Where(p => p.Category.Tier == 1 && p.Price < 900);*/
        
        var r1 = from p in products
            where p.Category.Tier == 1 && p.Price < 900.0
            select p.Category.Tier;
        
        Print("TIER 1 AND PRICE <900: ", r1);

        /*var r2 = products.
            Where(p => p.Category.Name == "Tools").
            Select(p => p.Name);*/
        
        var r2 = from p in products
            where p.Category.Name == "Tools"
            select p.Name;

        Print("NAMES OF PRODUCTS FROM TOOLS", r2);

        var r3 = products
            .Where(p => p.Category.Name == "Eletronics")
            .Select(p => p.Name);
        
        Print("NAMES OF PRODUCTS FROM ELETRONICS", r3);

        var r4 = products.Where(p => p.Category.Tier == 1)
            .OrderBy(p => p.Price)
            .ThenBy(p => p.Name);
        
        Print("TIER 1 ORDER BY PRICE THEN BY NAME", r4);

        var r5 = r4
            .Skip(2)
            .Take(4);
        
        Print("TIER 1 ORDER BY PRICE THEN BY NAME SKIP 2 TAKE 4", r5);

        var r6 = products
            .First();
        
        Console.WriteLine("First test1: " + r6);

        var r7 = products
            .Where(p => p.Price > 3000).FirstOrDefault();
        
        Console.WriteLine("Test 2:" + r7);

        // ReSharper disable once ReplaceWithSingleCallToSingleOrDefault
        var r8 = products
            .Where(p => p.Id == 3).SingleOrDefault();
        
        Console.WriteLine("Test 3:" + r8);

        var r9 = products
            .Where(p => p.Id == 30).SingleOrDefault();
        
        Console.WriteLine("Test 4:" + r9);

        var r10 = products
            .Max(p => p.Price);
        
        Console.WriteLine("Max Price: " + r10);

        var r11 = products
            .Min(p => p.Price);
        
        Console.WriteLine("Min Price: " + r11);
        
        var r12 =
            from p in products
            group p by p.Category;
        Console.WriteLine("Grupado: " +r12);
        foreach (IGrouping<Category,Product> group in r12)
        {
            Console.WriteLine("Category" + group.Key.Name+ ":");
            foreach (Product p in group)
            {
                Console.WriteLine(p);
            }
        }
    }
}