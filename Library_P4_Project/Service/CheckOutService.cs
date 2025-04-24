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
    public class CheckOutService
    {
        private AppDbContext _appDbContext;
        public CheckOutService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<CheckOuts> GetAll()
        {
            return _appDbContext.CheckOuts;
        }
        public async Task<int> Add(CheckOuts addCheck)
        {
            _appDbContext.CheckOuts.Add(addCheck);
            return await _appDbContext.SaveChangesAsync();
        }
        public async Task<int> Remove(CheckOuts deleteCheck)
        {
            _appDbContext.CheckOuts.Remove(deleteCheck);
            return await _appDbContext.SaveChangesAsync();
        }
        public async Task<int> Edit(CheckOuts editCheck, CheckOuts newCheck)
        {
            editCheck.Reader = newCheck.Reader;
            editCheck.Phone = newCheck.Phone;
            editCheck.CheckInDate = newCheck.CheckInDate;
            _appDbContext.CheckOuts.AddOrUpdate(editCheck);
            return await _appDbContext.SaveChangesAsync();
        }
    }
}
