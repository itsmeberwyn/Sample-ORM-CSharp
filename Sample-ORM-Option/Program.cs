// See https://aka.ms/new-console-template for more information
using Dapper;
using Sample_ORM_Option.Dapper;
using Sample_ORM_Option.EF;
using System;

class Program
{
    static void Main()
    {
        // using Dapper
        var categoryService = new Sample_ORM_Option.Dapper.CategoryService();
        int id = categoryService.Create("Food");

        var productService = new Sample_ORM_Option.Dapper.ProductService();
        productService.Create("Hotdog", 12, id);

        var products = productService.GetAll();
        foreach (var product in products)
        {
            Console.WriteLine($"Product: {product.Name}, Price: {product.Price}, Category: {product.Category.Name}");
        }

        // using EF
        //var categoryService = new CategoryService();
        //categoryService.Seed();
        //var categories = categoryService.GetCategories();
        //foreach (var category in categories)
        //{
        //    Console.WriteLine($"ID: {category.Id}, Name: {category.Name}");
        //}

        //var productService = new ProductService();
        //var rand = new Random();
        //productService.AddProduct(new Product { Name = "Laptop", Price = 1200, CategoryId = categories[rand.Next(categories.Count)].Id });
        //var products = productService.GetProducts();
        //foreach (var product in products)
        //{
        //    Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price}, Category: {product.Category.Name}");
        //}
    }
}
