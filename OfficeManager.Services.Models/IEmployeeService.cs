using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace OfficeManager.Services.Models
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployeesAync();
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task<Employee> CreateEmployeeAsync(EmployeeRequest createRequest);
        Task<Employee> UpdateEmployeeByIdAsync(EmployeeRequest updateRequest, int id);
        Task<Employee> RemoveEmployeeByIdAsync(int id);
        Task<bool> SetEmployeeStatusByIdAsync(int id, bool status);
    }
}
