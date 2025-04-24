using Library_P4_Project.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_P4_Project.Persistence
{
    public interface IAppDbContext
    {
        DbSet<BookCategories> BookCategories { get; set; }
        DbSet<Books> Books { get; set; }
        DbSet<CheckOuts> CheckOuts { get; set; }
        Task<int> SaveChangesAsync();
    }
}
