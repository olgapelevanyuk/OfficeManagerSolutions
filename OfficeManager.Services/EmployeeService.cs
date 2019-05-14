using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EmployeeBll = OfficeManager.Services.Models.Employee;
using OfficeManager.DataAccess.Models;
using EmployeeDb = OfficeManager.DataAccess.Models.Employee;
using OfficeManager.Services.Models;
using AutoMapper;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OfficeManager.Services.Models.ServiceExceptions;

namespace OfficeManager.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeContext _cntx;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeContext cntx, IMapper mapper)
        {
            _cntx = cntx ?? throw new ArgumentNullException(nameof(cntx));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<EmployeeBll> CreateEmployeeAsync(EmployeeRequest createRequest)
        {
            var dbToCreate = _mapper.Map<EmployeeDb>(createRequest);

            dbToCreate.Created = DateTime.UtcNow;
            dbToCreate.Updated= DateTime.UtcNow;

            var created = await _cntx.Employees.AddAsync(dbToCreate);

            var result = await _cntx.SaveChangesAsync();

            if(result <= 0)
            {
                throw new Exception();
            }

            return _mapper.Map<EmployeeBll>(created.Entity);
        }

        public async Task<EmployeeBll> GetEmployeeByIdAsync(int id)
        {
            var employeeDb = await _cntx.Employees.Where(emp => emp.Id == id).ToArrayAsync();

            if(employeeDb.Length == 0)
            {
                throw new InvalidArgumentException("Employee with such id not found!");
            }

            var mapped = _mapper.Map<EmployeeBll>(employeeDb[0]);

            return mapped;
        }

        public async Task<IEnumerable<EmployeeBll>> GetEmployeesAync()
        {
            var employeesDb = await _cntx.Employees.ToListAsync();

            return employeesDb.Select(emp => _mapper.Map<EmployeeBll>(emp));
        }

        public async Task<EmployeeBll> RemoveEmployeeByIdAsync(int id)
        {
            var employeeDbToRemove = await _cntx.Employees.Where(emp => emp.Id == id).ToArrayAsync();

            if(employeeDbToRemove.Length == 0)
            {
                throw new InvalidArgumentException("Employee with such id not found!");
            }

            var removed = _cntx.Employees.Remove(employeeDbToRemove[0]);

            var result = await _cntx.SaveChangesAsync();

            if(result <= 0)
            {
                throw new Exception();
            }

            return _mapper.Map<EmployeeBll>(removed);
        }

        public async Task<bool> SetEmployeeStatusByIdAsync(int id, bool status)
        {
            var employeeDbToSetStatus = await _cntx.Employees.Where(emp => emp.Id == id).ToArrayAsync();
            
            if(employeeDbToSetStatus.Length == 0)
            {
                throw new InvalidArgumentException("Employee with such id not found!");
            }

            employeeDbToSetStatus[0].IsDeleted = status;

            var result = await _cntx.SaveChangesAsync();

            if(result <= 0)
            {
                throw new Exception();
            }

            return true;
        }

        public async Task<EmployeeBll> UpdateEmployeeByIdAsync(EmployeeRequest updateRequest, int id)
        {
            var employeeDbToUpdate = await _cntx.Employees.Where(emp => emp.Id == id).ToArrayAsync();

            if (employeeDbToUpdate.Length == 0)
            {
                throw new InvalidArgumentException("Employee with such id not found!");
            }

            var mapped = _mapper.Map<EmployeeDb>(updateRequest);

            mapped.Id = employeeDbToUpdate[0].Id;

            var updated = _cntx.Employees.Update(mapped);

            var result = await _cntx.SaveChangesAsync();

            if (result <= 0)
            {
                throw new Exception();
            }

            return _mapper.Map<EmployeeBll>(updated.Entity);
        }
    }
}
