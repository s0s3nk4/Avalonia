using Library_P4_Project.Model;
using Library_P4_Project.Persistence;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_P4_Project.Service
{
    public class CategoryService
    {
        private AppDbContext _appDbContext;
        public CategoryService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<BookCategories> GetAll()
        {
            return _appDbContext.BookCategories;
        }
        public async Task<int> Add(BookCategories addCategory)
        {
            _appDbContext.BookCategories.Add(addCategory);
            return await _appDbContext.SaveChangesAsync();
        }
        public async Task<int> Remove(BookCategories deleteCategory)
        {
            _appDbContext.BookCategories.Remove(deleteCategory);
            return await _appDbContext.SaveChangesAsync();
        }
        public async Task<int> Edit(BookCategories editCategory, string newCategory)
        {
            editCategory.Name = newCategory;
            _appDbContext.BookCategories.AddOrUpdate(editCategory);
            return await _appDbContext.SaveChangesAsync();
        }
    }
}
