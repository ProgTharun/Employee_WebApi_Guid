using Employee_WebApi.Model;
using Employee_WebApi.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Employee_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var emp = _employeeService.GetAll();
            return Ok(emp);
        }
        [HttpGet("Id/{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(_employeeService.GetById(id));
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee employee)
        {

            if (!ModelState.IsValid)
            {
                var errors = string.Join("; ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                throw new ValidationException($"{errors}");
            }
            _employeeService.AddEmployee(employee); 
            return Ok(employee);
        }
    }
}


