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
    public class SeedController : ControllerBase
    {
        private readonly csMainDbContext _context;

        public SeedController(csMainDbContext.SqlServerDbContext context)
        {
            _context = context;
        }

        [HttpPost("Seed")]
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

        [HttpPost("clearSeededData")]
        public IActionResult ClearSeededData()
        {
            try
            {
                // Remove seeded data
                _context.Users.RemoveRange(_context.Users);
                _context.Address.RemoveRange(_context.Address);
                _context.Attraction.RemoveRange(_context.Attraction);
                _context.Comment.RemoveRange(_context.Comment);
                _context.SaveChanges();

                return Ok("Seeded data removed successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error occurred while clearing seeded data: {ex.Message}");
            }
        }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class InfoController : ControllerBase
    {
        private readonly csMainDbContext _context;

        public InfoController(csMainDbContext.SqlServerDbContext context)
        {
            _context = context;
        }

        [HttpGet("User Data")]
        public IActionResult GetAll()
        {
            var users = _context.Users
            .Include(u => u.Comments)
            .Select(u => new
            {
                u.UserID,
                u.UserName,
                Comments = u.Comments.Count
            }).ToList();

            return Ok(users);
        }
        [HttpGet("All data")]
        public IActionResult GetInfo()
        {
            var info = new
            {
                UsersCount = _context.Users.Count(),
                CommentsCount = _context.Comment.Count(),
                AttractionsCount = _context.Attraction?.Count() ?? 0,
                AddressesCount = _context.Address?.Count() ?? 0
            };

            return Ok(info);
        }
    }
}