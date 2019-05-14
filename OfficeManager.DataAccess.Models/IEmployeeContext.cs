using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OfficeManager.DataAccess.Models
{
    public interface IEmployeeContext
    {
        DbSet<Employee> Employees { get; }

        Task<int> SaveChangesAsync();
    }
}
