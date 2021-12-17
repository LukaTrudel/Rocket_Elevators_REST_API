using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using RocketApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using Microsoft.AspNetCore.Http;


namespace RocketApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColumnsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public ColumnsController(ApplicationContext context) 
        {
            _context = context;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Column>>> GetAllColumns()
        {
            return await _context.columns
            .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Column>> GetColumnId(long id)
        {
            var column = await _context.columns.FindAsync(id);

            if (column == null)
            {
                return NotFound();
            }

            return column;
        }
        [HttpGet("find-columns/{id}")]
        public ActionResult<List<Column>> GetColumnsFromBattery(long id)
        {
            List<Column> columns = _context.columns.ToList();
            List<Column> batteryColumns = new List<Column>();
            foreach (Column column in columns)
            {
                if (column.BatteryId == id)
                {
                    batteryColumns.Add(column);
                }
            }
            return batteryColumns;
        }
        

        [HttpGet("{id}/status")]
        public async Task<ActionResult<string>> GetColumnStatus(long id)
        {
            var column = await _context.columns.FindAsync(id);
            if (column == null)
            {
                return NotFound();
            }
            return column.Status;
        }

        [HttpGet("update/{id}/{status}")]
        public async Task<dynamic> test(string status, long id)
        {
            var column = await _context.columns.FindAsync(id);
            
            column.Status = status;
            await _context.SaveChangesAsync();         

            return column;
        }
    }  
}
