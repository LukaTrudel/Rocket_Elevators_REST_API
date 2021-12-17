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

    public class BatteriesController : ControllerBase
    {
        private readonly ApplicationContext _context;


        public BatteriesController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Battery>>> Getbatteries()
        {
            return await _context.batteries
            .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Battery>> GetBatteriesId(long id)
        {
            var batter = await _context.batteries.FindAsync(id);

            if (batter == null)
            {
                return NotFound();
            }

            return batter;
        }
        


        [HttpGet("{id}/status")]
        public async Task<ActionResult<string>> GetBatteryStatus(long id)
        {
            var battery = await _context.batteries.FindAsync(id);

            if (battery == null)
            {
                return NotFound();
            }

            return battery.Status;
        }
        [HttpGet("find-batteries/{id}")]
        public ActionResult<List<Battery>> GetBatteriesFromBuilding(long id)
        {
            List<Battery> batteries = _context.batteries.ToList();
            List<Battery> buildingBatteries = new List<Battery>();
            foreach (Battery battery in batteries)
            {
                if (battery.BuildingId == id)
                {
                    buildingBatteries.Add(battery);
                }
            }
            return buildingBatteries;
        }

        [HttpGet("update/{id}/{status}")]
        public async Task<dynamic> test(string status, long id)
        {
            var battery = await _context.batteries.FindAsync(id);

            battery.Status = status;
            await _context.SaveChangesAsync();         

            return battery;
        }
    }
} 