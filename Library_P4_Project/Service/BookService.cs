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
    public class BookService
    {
        private AppDbContext _appDbContext;
        public BookService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Books> GetAll()
        {
            return _appDbContext.Books;
        }
        public async Task<int> Add(Books addBook)
        {
            _appDbContext.Books.Add(addBook);
            return await _appDbContext.SaveChangesAsync();
        }
        public async Task<int> Remove(Books deleteBook)
        {
            _appDbContext.Books.Remove(deleteBook);
            return await _appDbContext.SaveChangesAsync();
        }
        public async Task<int> Edit(Books editBook, Books newBook)
        {
            editBook.Title = newBook.Title;
            editBook.Description = newBook.Description;
            editBook.Author = newBook.Author;
            _appDbContext.Books.AddOrUpdate(editBook);
            return await _appDbContext.SaveChangesAsync();
        }
    }
}
