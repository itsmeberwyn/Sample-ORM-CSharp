using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_ORM_Option.EF
{
    class CategoryService
    {
        private readonly ProductDBContext _context;

        public CategoryService()
        {
            _context = new ProductDBContext();
        }

        public void Seed()
        {
            string title = "Electronic";
            var res = _context.Categories.Where(e => e.Name == title).FirstOrDefault();
            if (res == null)
            {
                var category = new Category { Name = title };
                _context.Categories.Add(category);
                _context.SaveChanges();
            }
        }

        public List<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }
    }
}
