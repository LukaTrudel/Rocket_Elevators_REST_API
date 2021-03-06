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

       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Address>>> Getaddresses()
        {
            return await _context.addresses.ToListAsync();
        }


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
        [HttpGet("City")]
        public async Task<List<string>> GetCitys(string city) 
        {
            
            var numCity = await _context.addresses.Select(c => c.city).Distinct().ToListAsync();
            
            return numCity;
        }



        // [HttpGet("City")]
        // public async Task<List<int>> GetCitys() 
        // {
        //     var arrayAPI = new List<int>();
        //     var numOfAddresses = await _context.addresses.Select(c => c.city).Distinct().ToListAsync();
        //     arrayAPI.Add(numOfAddresses.Count);
        //     return arrayAPI;
        // }


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