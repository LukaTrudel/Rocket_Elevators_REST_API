using System;
using Microsoft.AspNetCore.Http;
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
    public class InterventionsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public InterventionsController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Interventions>>> GetInterventions()
        {
            var _intervention = await _context.interventions.ToListAsync();
            var interventionsList = new List<Interventions>(){};

            foreach(Interventions interventions in _intervention)
            {
                if(interventions.start_of_intervention == null && interventions.status == "Pending")
                {
                    interventionsList.Add(interventions);
                }
            }
            
            return interventionsList;
        }
        [HttpGet("{id}/status")]
        public async Task<ActionResult<string>> GetInterventionStatus(long id)
        {
            var inter = await _context.interventions.FindAsync(id);

            if (inter == null)
            {
                return NotFound();
            }

            return inter.status;
        }
        // PUT Request to change specified intervention status to In Progess or Completed
        [HttpPut("{id}/{status}")]
        public async Task<ActionResult<Interventions>> StartIntervention(long id, string status)
        {
            var intervention = await _context.interventions.FindAsync(id);
            intervention.status = status;

            if(status == "InProgress")
            {
                intervention.start_of_intervention = DateTime.Now;
                await _context.SaveChangesAsync();
                return intervention;
            }
            else if(status == "Completed")
            {
                intervention.end_of_intervention = DateTime.Now;
                await _context.SaveChangesAsync();
                return intervention;
            }

            return Ok("Invalid Endpoint!");
        }
        [HttpPost("create")]
        public async Task<ActionResult<Interventions>> PostIntervention(Interventions intervention)
        {
            intervention.created_at = DateTime.Now;
            intervention.updated_at = DateTime.Now;
            _context.interventions.Add(intervention);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInterventions", new { id = intervention.Id }, intervention);
        }
    }
}