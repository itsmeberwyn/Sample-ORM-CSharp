using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_ORM_Option.Dapper
{
    class ProductService
    {
        IDbConnection connection;
        public ProductService()
        {
            connection = DatabaseHelper.GetConnection();
        }
        public void Create(string name, decimal price, int categoriId)
        {
            connection.Execute("INSERT INTO \"Products\" (\"Name\", \"Price\", \"CategoryId\") VALUES (@Name, @Price, @CategoryId);", new {Name=name, Price=price, CategoryId=categoriId});
            Console.WriteLine("Product Successfully Created!");
        }

        public List<Product> GetAll()
        {
            // use lowercase on creating tables, to avoid getting error on something like this,
            // and when mapping you can just use alias to map the response to entity
            string sql = "SELECT \"p.Id\", \"p.Name\", \"p.Price\", \"p.CategoryId\", \"c.Id\" AS \"CategoryId\", \"c.Name\" AS CategoryName FROM \"Products\" p INNER JOIN \"Categories\" c ON \"p.CategoryId\" = \"c.Id\";";

            var productDictionary = new Dictionary<int, Product>();

            var products = connection.Query<Product, Category, Product>(
                sql,
                (product, category) =>
                {
                    if (!productDictionary.TryGetValue(product.Id, out var existingProduct))
                    {
                        existingProduct = product;
                        existingProduct.Category = category;
                        productDictionary.Add(existingProduct.Id, existingProduct);
                    }
                    return existingProduct;
                },
                splitOn: "CategoryId"
            ).Distinct().ToList();

            return products;
        }
    }
}
