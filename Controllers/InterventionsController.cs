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
        public async Task<ActionResult<IEnumerable<Interventions>>> Getinterventions()
        {
            return await _context.interventions.ToListAsync();
        }

        [HttpGet("{email}/status")]
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
        [HttpGet("{id}/inProgress")]
        public async Task<ActionResult<Interventions>> setInProgress(long id)
        {
            var intervention = await _context.interventions.FindAsync(id);
            if (intervention == null) return NotFound();

            intervention.start_of_intervention = DateTime.Now;
            intervention.status = "InProgress";

            if (intervention.status != "Completed")
            {
                _context.interventions.Update(intervention);
                _context.SaveChanges();
            }
            
             


            return intervention;
        }

        [HttpGet("{id}/completed")]
        public async Task<ActionResult<Interventions>> setToCompleted(long id)
        {
            var intervention = await _context.interventions.FindAsync(id);
            if (intervention == null) return NotFound();

            intervention.end_of_intervention = DateTime.Now;
            intervention.status = "Completed";

            if (intervention.status == "InProgress")
            {
                _context.interventions.Update(intervention);
                _context.SaveChanges();
            }

            return intervention;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Interventions>> GetIntervention(long id)
        {
            var intervention = await _context.interventions.FindAsync(id);

            if (intervention == null)
            {
                return NotFound();
            }

            return intervention;
        }
        [HttpPost]
        public async Task<ActionResult<Interventions>> PostIntervention(Interventions intervention)
        {

            intervention.created_at = DateTime.Now;
            intervention.updated_at = DateTime.Now;

            _context.interventions.Add(intervention);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIntervention", new { id = intervention.Id }, intervention);
        }
        // [HttpPost]
        // public async Task<ActionResult<Interventions>> PostIntervention(Interventions newIntervention)
        // {
        //     newIntervention.created_at= DateTime.Now;
        //     newIntervention.status = "InProgress";
        //     newIntervention.result = "Incomplete";
        //     newIntervention.employee_id = null;

        //     _context.interventions.Add(newIntervention);
        //     await _context.SaveChangesAsync();

        //     return NoContent();
        // }

        // private bool InterventionExists(long id)
        // {
        //     return _context.interventions.Any(e => e.Id == id);
        // }
        
        
    }
}