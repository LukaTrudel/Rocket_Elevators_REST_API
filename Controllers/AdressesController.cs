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
    public class AddressesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public AddressesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Addresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Address>>> Getaddresses()
        {
            return await _context.addresses.ToListAsync();
        }

//----------------------------------- Retrieving all information from a specific Address -----------------------------------\\
        // GET: api/Addresses/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Address>> GetAddress(long id)
        {
            var address = await _context.addresses.FindAsync(id);

            if (address == null)
            {
                return NotFound();
            }

            return address;
        }

//----------------------------------- Retrieving all building addresses -----------------------------------\\
        // GET: api/Addresses/City
        [HttpGet("City")]
        public object GetCitys()
        {
            return _context.addresses.Where(addresses => addresses.entity == "Building"); 
        }

//----------------------------------- Update information from a specific Address -----------------------------------\\

        // PUT: api/Addresses
        [HttpPut]
        public async Task<ActionResult<Address>> PutAddress(Address address)
        {
            var addressUpdate = await _context.addresses
                                                .Where(add => add.postalCode == address.postalCode)
                                                .FirstOrDefaultAsync(); 

            if (addressUpdate == null)
            {
                return NotFound();
            }

            addressUpdate.numberAndStreet = address.numberAndStreet;
            addressUpdate.city = address.city;
            addressUpdate.postalCode = address.postalCode;
            addressUpdate.country = address.country;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AddressExists(long id)
        {
            return _context.addresses.Any(e => e.id == id);
        }
    }
}