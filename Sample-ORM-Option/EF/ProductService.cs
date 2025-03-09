using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_ORM_Option.EF
{
    class ProductService
    {
        private readonly ProductDBContext _context;

        public ProductService()
        {
            _context = new ProductDBContext();
        }

        // Create
        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            Console.WriteLine("Product added successfully!");
        }

        // Read (Get All)
        public List<Product> GetProducts()
        {
            return _context.Products.Include(p => p.Category).ToList();
        }

        // Read (Get by Id)
        public Product GetProductById(int id)
        {
            return _context.Products.Find(id);
        }

        // Update
        public void UpdateProduct(int id, string newName, decimal newPrice)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                product.Name = newName;
                product.Price = newPrice;
                _context.SaveChanges();
                Console.WriteLine("Product updated successfully!");
            }
            else
            {
                Console.WriteLine("Product not found!");
            }
        }

        // Delete
        public void DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
                Console.WriteLine("Product deleted successfully!");
            }
            else
            {
                Console.WriteLine("Product not found!");
            }
        }
    }
}
