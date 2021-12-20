using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using RocketApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace RocketApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public CustomersController(ApplicationContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>>  GetCustomers()
        {
            return await _context.customers.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomerId(long id)
        {
            var customer = await _context.customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }
        // [HttpGet("FullInfo/{email}")]
        // public async Task<ActionResult<Customer>> GetCustomer(string email)
        // {
            
        //     var customer = await _context.customers.Include("Buildings.Batteries.Columns.Elevators")
        //                                             .Where(c => c.Email == email)
        //                                             .FirstOrDefaultAsync();                     

        //     if (customer == null)
        //     {
        //         return NotFound();
        //     }

        //     return customer;
        // } 

        [HttpGet("{email}/customer")]
        public object GetBuildingsByCustomerEmail(string email)
        {
            return _context.customers.Where(c => c.Email == email);
        } 

        [HttpGet("verify/{email}")]
        public async Task<ActionResult<Customer>> GetInfoCustomer(string email)
        {
            var customer = await _context.customers.FirstOrDefaultAsync(customer => customer.Email == email);
                                               
                                           
            System.Console.WriteLine(customer);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        [HttpPut]
        public async Task<ActionResult<Customer>> PutCustomer(Customer customer)
        {
            var customerToUpdate = await _context.customers
                                                .Where(c => c.Email == customer.Email)
                                                .FirstOrDefaultAsync();

            if (customerToUpdate == null)
            {
                return NotFound();
            }

            customerToUpdate.compagnyName = customer.compagnyName;
            customerToUpdate.FullName = customer.FullName;
            customerToUpdate.ContactPhone = customer.ContactPhone;
            customerToUpdate.FullNameTechnicalAuthority = customer.FullNameTechnicalAuthority;
            customerToUpdate.TechnicalAuthorityPhone = customer.TechnicalAuthorityPhone;
            customerToUpdate.TechnicalAuthorityEmail = customer.TechnicalAuthorityEmail;
            customerToUpdate.Description = customer.Description;

            await _context.SaveChangesAsync();

            return customerToUpdate;
        }
    

    }

   
}
