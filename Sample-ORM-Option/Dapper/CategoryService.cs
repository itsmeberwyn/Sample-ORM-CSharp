using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_ORM_Option.Dapper
{
    class CategoryService
    {
        IDbConnection connection;
        public CategoryService()
        {
            connection = DatabaseHelper.GetConnection();
        }
        public int Create(string name)
        {
            int id = connection.Execute("INSERT INTO \"Categories\" (\"Name\") VALUES (@Name) RETURNING \"Id\";", new {Name = name});
            Console.WriteLine("Category Successfully Created!");
            return id;
        }
    }
}
