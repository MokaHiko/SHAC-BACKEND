using Microsoft.AspNetCore.Mvc;
using sugar_hills_backend.Data.SHAC;
using sugar_hills_backend.Models.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sugar_hills_backend.Controllers
{
    public class SHACController : ControllerBase
    {
        private readonly ISHACRepo _shacRepo;

        public SHACController(ISHACRepo shacRepo)
        {
            _shacRepo = shacRepo;
        }

        [HttpGet("api/shac/employees")]
        public async Task<IActionResult> GetEmployees()
        {
            return Ok(await _shacRepo.GetEmployees());
        }

        [HttpPost("api/shac/employees")]
        public async Task<IActionResult> AddEmployee([FromBody] CreateEmployeeDTO employee)
        {
            var result = await _shacRepo.AddEmployee(employee);
            if (result > 0)
            {
                return Ok(new { Message = "Employee Added." });
            }

            return StatusCode(500, new { Message = "Unable to Add Employee" });
        }

        [HttpDelete("api/shac/employees")]
        public async Task<IActionResult> RemoveEmployee([FromBody] RemoveEmployeeDTO employee)
        {
            var result = await _shacRepo.RemoveEmployee(employee);
            if (result > 0)
            {
                return StatusCode(200, new { Message = $"#{employee.ID} deleted" });
            }
            return StatusCode(404, new { Message = $"Failed to Delete #{employee.ID}" });
        }

        [HttpPost("api/shac/timecard/employees")]
        public async Task<IActionResult> GetEmployeeFromDay([FromBody] GetEmployeesFromDayDTO Date)
        {
            var result = await _shacRepo.GetEmployeesFromDay(Date);
            return Ok(result);
        }
        

        [HttpPost("api/shac/timecard")]
        public async Task<IActionResult> AddEmployeeToTimeCard([FromBody] AddToTimeCardDTO employee)
        {
            var result = await _shacRepo.AddEmployeeToDay(employee);
            if (result > 0)
            {
                return Ok(new { Message = "Employee Added To Day." });
            }

            return StatusCode(500, new { Message = "Unable to Add Employee" });
        }

        [HttpDelete("api/shac/timecard")]
        public async Task<IActionResult> RemoveEmployeeFromDay([FromBody] RemoveEmployeeFromTimeCardDTO employee)
        {
            var result = await _shacRepo.RemoveEmployeeFromDay(employee);
            if (result > 0)
            {
                return StatusCode(200, new { Message = $"#{employee.ID} deleted from {employee.TimeIn.Day}" });
            }
            return StatusCode(404, new { Message = $"Failed to Delete #{employee.ID} from {employee.TimeIn.Day}"});
        }
    }
}
