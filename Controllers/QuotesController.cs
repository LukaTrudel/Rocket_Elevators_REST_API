using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.Linq;
using System.IO;
using RocketApi.Models;

namespace RocketApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public QuotesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET all quotes
        [HttpGet]
        public async Task<dynamic> GetQuotes()
        {
            var quotes = await _context.quotes.ToListAsync();
            return quotes;
        }
    }
}