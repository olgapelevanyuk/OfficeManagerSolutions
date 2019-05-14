using AutoMapper;
using OfficeManager.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using EmployeeDb = OfficeManager.DataAccess.Models.Employee;

namespace OfficeManager.Services
{
    public class EmployeeMappingProfile : Profile
    {
        public EmployeeMappingProfile()
        {
            CreateMap<EmployeeDb, Employee>();
            CreateMap<EmployeeRequest, EmployeeDb>();
        }
    }
}
