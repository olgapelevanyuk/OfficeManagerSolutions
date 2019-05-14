using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeManager.Services.Models;
using OfficeManager.Services.Models.ServiceExceptions;

namespace OfficeManager.WebApi.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _empService;

        public EmployeesController(IEmployeeService empService)
        {
            _empService = empService ?? throw new ArgumentNullException(nameof(empService));
        }

        [HttpGet]
        public async Task<CustomServerResponse<IEnumerable<Employee>>> GetEmployeesAsync()
        {
            try
            {
                var employees = await _empService.GetEmployeesAync();

                return new CustomServerResponse<IEnumerable<Employee>>
                {
                    Data = employees,
                    Message = "Employees returned",
                    StatusCode = StatusCodes.Status200OK
                }; 
            }
            catch(Exception ex)
            {
                return new CustomServerResponse<IEnumerable<Employee>>
                {
                    Data = null,
                    Message = "Some error occured while processing request!",
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
        }

        [HttpGet("{id}")]
        public async Task<CustomServerResponse<Employee>> GetEmployeeByIdAsync(int id)
        {
            try
            {
                var employee = await _empService.GetEmployeeByIdAsync(id);

                return new CustomServerResponse<Employee>
                {
                    Data = employee,
                    Message = "Employees returned",
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                return new CustomServerResponse<Employee>
                {
                    Data = null,
                    Message = "Some error occured while processing request!",
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
        }

        [HttpPost]
        public async Task<CustomServerResponse<Employee>> CreateEmployeeAsync([FromBody] EmployeeRequest employeeCreateRequest)
        {
            try
            {
                var created = await _empService.CreateEmployeeAsync(employeeCreateRequest);

                return new CustomServerResponse<Employee>
                {
                    Data = created,
                    Message = "Employee successfully created",
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch(InvalidArgumentException ex)
            {
                return  new CustomServerResponse<Employee>
                {
                    Data = null,
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
            catch (Exception ex)
            {
                return new CustomServerResponse<Employee>
                {
                    Data = null,
                    Message = "Some error occured while processing request!",
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
        }

        [HttpPut("{id}")]
        public async Task<CustomServerResponse<Employee>> UpdateEmployeeByIdAsync(int id,[FromBody]EmployeeRequest employeeUpdateRequest)
        {
            try
            {
                var updated = await _empService.UpdateEmployeeByIdAsync(employeeUpdateRequest,id);
               
                return new CustomServerResponse<Employee>
                {
                    Data = updated,
                    Message = "Employee successfully updated",
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (InvalidArgumentException ex)
            {
                return new CustomServerResponse<Employee>
                {
                    Data = null,
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
            catch (Exception ex)
            {
                return new CustomServerResponse<Employee>
                {
                    Data = null,
                    Message = "Some error occured while processing request!",
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
        }

        [HttpDelete("{id}")]
        public async Task<CustomServerResponse<Employee>> RemoveEmployeeByIdAsync(int id)
        {
            try
            {
                var removed = await _empService.RemoveEmployeeByIdAsync(id);

                return new CustomServerResponse<Employee>
                {
                    Data = removed,
                    Message = "Employee successfully removed",
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                return new CustomServerResponse<Employee>
                {
                    Data = null,
                    Message = "Some error occured while processing request!",
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
        }
        [HttpPut("{id}/status")]
        public async Task<CustomServerResponse<bool>> SetEmployeeDeleteStatusByIdAsync(int id,[FromBody]bool status)
        {
            try
            {
                var setted = await _empService.SetEmployeeStatusByIdAsync(id,status);

                return new CustomServerResponse<bool>
                {
                    Data = setted,
                    Message = "Employee successfully removed",
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                return new CustomServerResponse<bool>
                {
                    Data = false,
                    Message = "Some error occured while processing request!",
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}
