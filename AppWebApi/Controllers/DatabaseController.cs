using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Configuration;
using Models;

using Services;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Filters;
using DbContext;
using DbModels;

namespace AppWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatabaseController : ControllerBase
    {
        private readonly csMainDbContext _context;

        public DatabaseController(csMainDbContext context)
        {
            _context = context;
        }

        [HttpGet("seed")]
        public IActionResult SeedDatabase()
        {
            try
            {
                csSeedGenerator seedGenerator = new csSeedGenerator(_context);
                seedGenerator.GenerateData();

                return Ok("Database seeded successfully");
            }
            catch (Exception ex)
            {
                // Handle any error that occurs during the seeding process
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly csMainDbContext _context;

        public UsersController(csMainDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _context.Users.ToList();
            return Ok(users);
        }
    }
}