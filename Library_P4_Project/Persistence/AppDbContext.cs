using Library_P4_Project.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_P4_Project.Persistence
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(string connectionString) : base(connectionString)
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<AppDbContext>());
        }
        public DbSet<BookCategories> BookCategories { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<CheckOuts> CheckOuts { get; set; }
        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }
    }
}
