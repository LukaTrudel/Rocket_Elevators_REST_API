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
    public class BuildingsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public BuildingsController(ApplicationContext context) 
        {
            _context = context;
        }

        public Building buildingsFindById(long id, List<Building> listBuilding) 
        {
            foreach (Building building in listBuilding) 
            {
                if (building.Id == id) 
                {
                    return building;
                }
            }
            return null;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Building>>> getAllBuildings()
        {
            return await _context.buildings.ToListAsync();
        }
        [HttpGet("{email}/customer")]
        public object GetBuildingsByCustomerEmail(string email)
        {
            var customer =_context.customers.Where(c => c.Email == email).FirstOrDefault();
            return _context.buildings.Where(b => b.CustomerId == customer.Id);
        }     

        

        [HttpGet]
        public List<Building> GetBuildings()
        {
            var buildings = _context.buildings.ToList();
            var batteries = _context.batteries.ToList();
            var columns = _context.columns.ToList();
            var elevators = _context.elevators.ToList();

            var filteredBatteries = batteries.Where(battety => battety.Status == "intervention").ToList();
            var filteredColumns = columns.Where(column => column.Status == "intervention").ToList();
            var filteredElevators = elevators.Where(elevator => elevator.Status == "intervention").ToList();

            List<Building> result = new List<Building>();
            foreach (Battery battery in filteredBatteries) 
            {
                var containerBuilding = buildingsFindById(battery.BuildingId, buildings);
                if (containerBuilding != null && battery.getColumnList(filteredColumns, filteredElevators) && !result.Contains(containerBuilding)) 
                {
                    result.Add(containerBuilding);
                }
            }
            return result;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Building>> GetBuildingId(long id)
        {
            var building = await _context.buildings.FindAsync(id);

            if (building == null)
            {
                return NotFound();
            }

            return building;
        }
        
    }
    
}
