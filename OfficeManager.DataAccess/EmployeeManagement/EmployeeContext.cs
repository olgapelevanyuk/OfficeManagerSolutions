using Microsoft.EntityFrameworkCore;
using OfficeManager.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OfficeManager.DataAccess.EmployeeManagement
{
    public class EmployeeContext : IEmployeeContext
    {
        private readonly ApplicationDbContext _cntx;

        public EmployeeContext(ApplicationDbContext cntx)
        {
            _cntx = cntx ?? throw new ArgumentNullException(nameof(cntx));
        }

        public DbSet<Employee> Employees => _cntx.Employees;

        public Task<int> SaveChangesAsync() => _cntx.SaveChangesAsync();
    }
}
