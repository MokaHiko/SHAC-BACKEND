using sugar_hills_backend.Models.DTOS;
using sugar_hills_backend.Models.SHAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sugar_hills_backend.Data.SHAC
{
    public interface ISHACRepo
    {
        Task<IEnumerable<SHACEmployee>> GetEmployees();
        Task<int> AddEmployee(CreateEmployeeDTO employee);
        Task<int> RemoveEmployee(RemoveEmployeeDTO EmployeeID);
        Task<IEnumerable<ShacTimeCardDTO>> GetEmployeesFromDay(GetEmployeesFromDayDTO Date);
        Task<int> AddEmployeeToDay(AddToTimeCardDTO employee);
        Task<int> RemoveEmployeeFromDay(RemoveEmployeeFromTimeCardDTO Employee);
    }
}
