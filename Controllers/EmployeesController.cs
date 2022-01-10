using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RocketApi.Models;

namespace RocketApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public EmployeesController(ApplicationContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return await _context.employees.ToListAsync();
        }

        // GET: api/Employee/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(long id)
        {
            var employee = await _context.employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        //Validate user is a employee during registration
        // GET: api/Employee/Email/{federico@yost.biz}
        [HttpGet("Email/{email}")]
        public async Task<ActionResult<Employee>> GetEmployeeEmail(string email)
        {

            IEnumerable<Employee> employeesAll = await _context.employees.ToListAsync();

            foreach (Employee employee in employeesAll)
            {
                if (employee.email == email)
                {
                    return employee;
                }
            }
            return NotFound();
        }
    }
}