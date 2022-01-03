using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using RocketApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace RocketApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public LeadsController(ApplicationContext context) 
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lead>>> getLeads()
        {
            return await _context.leads.ToListAsync();
        }


        [HttpGet("filter")]
        public List<Lead> GetLeads()
        {
            var leads = _context.leads.ToList();
            var customers = _context.customers.ToList();
            List<Lead> notCustomers = new List<Lead>();
            DateTime currentDate = DateTime.Now;
            List<Lead> filteredLeads = leads.Where(lead => lead.Created_at > currentDate.AddDays(Convert.ToDouble(-30))).ToList();
            List<Customer> filteredCustomers = customers.Where(customer => customer.Created_at > currentDate.AddDays(Convert.ToDouble(-30))).ToList();
            foreach (Lead lead in filteredLeads)
            {
                foreach (Customer customer in filteredCustomers)
                {
                    if (lead.Email != customer.Email && lead.PhoneNumber != customer.ContactPhone && !notCustomers.Contains(lead)) {
                        notCustomers.Add(lead);
                    }
                }
            }
            return notCustomers;
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Lead>> GetLead(long id)
        {
            var lead = await _context.leads.FindAsync(id);

            if (lead == null)
            {
                return NotFound();
            }

            return lead;
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLead(long id, Lead lead)
        {
            if (id != lead.Id)
            {
                return BadRequest();
            }

            _context.Entry(lead).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeadExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Lead>> PostLead(Lead lead)
        {
            _context.leads.Add(lead);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLead", new { id = lead.Id }, lead);
        }

        
        [HttpDelete("{id}")]
        public async Task<ActionResult<Lead>> DeleteLead(long id)
        {
            var lead = await _context.leads.FindAsync(id);
            if (lead == null)
            {
                return NotFound();
            }

            _context.leads.Remove(lead);
            await _context.SaveChangesAsync();

            return lead;
        }

        private bool LeadExists(long id)
        {
            return _context.leads.Any(e => e.Id == id);
        }
    }
    
}
