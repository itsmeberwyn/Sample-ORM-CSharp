using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_ORM_Option.EF
{
    class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation Property (One-to-Many)
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
