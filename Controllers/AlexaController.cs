using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RocketApi.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RocketApi.Controllers
{
    [Route("api/[controller]")]
    public class AlexaController : ControllerBase
    {
        private readonly ApplicationContext _context;

        //Constructor
        public AlexaController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<dynamic> GetAllData()
        {
            var elevators = 0;
            var buildings = 0;
            var customers = 0;
            var stopped = 0;
            var batteries = 0;
            var quotes = 0;
            var leads = 0;

            var elevatorList = await _context.elevators.ToListAsync();
            var buildingList = await _context.buildings.ToListAsync();
            var customerList = await _context.customers.ToListAsync();
            var stoppedList =  from e in _context.elevators where e.Status == "Stopped" select e;
            var batteryList = await _context.batteries.ToListAsync();
            var quoteList = await _context.quotes.ToListAsync();
            var leadList = await _context.leads.ToListAsync();

            foreach(Elevator elevator in elevatorList){elevators++;}
            foreach(Building building in buildingList){buildings++;}
            foreach(Customer customer in customerList){customers++;}
            foreach(Elevator elevator in stoppedList){stopped++;}
            foreach(Battery battery in batteryList){batteries++;}
            foreach(Quotes quote in quoteList){quotes++;}
            foreach(Lead lead in leadList){leads++;}

            var data = new 
            {
                elevators = elevators,
                buildings = buildings,
                customers = customers,
                stopped = stopped,
                batteries = batteries,
                quotes = quotes,
                leads = leads
            };

            return data;
        }
    }
}