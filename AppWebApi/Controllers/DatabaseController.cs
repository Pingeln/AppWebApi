using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Configuration;
using Models;

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

        // seed the database with test data in line with requirments for the project
        [HttpPost("Seed as per G requirments")]
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

        // removes all the test data (we dont have any other data than test data)
        [HttpPost("Remove seeded data")]
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

        // shows some data about users, made this initially just to see if it works, will be removed
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

        // Shows what is currently populating the database 
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

    [Route("api/[controller]")]
    public class FilterController : ControllerBase
    {
        private readonly csMainDbContext _context;

        public FilterController(csMainDbContext.SqlServerDbContext context)
        {
            _context = context;
        }

        [HttpGet("Attractions filter")]
        public IActionResult GetFilteredAttractions(string? category, string? name, string? description, string? country, string? location)
        {
            var attractions = _context.Attraction
                            .Include(a => a.Address)
                            .Where(a => (string.IsNullOrEmpty(category) || a.Category == category) &&
                                        (string.IsNullOrEmpty(name) || a.Name.Contains(name)) &&
                                        (string.IsNullOrEmpty(description) || a.Description.Contains(description)) &&
                                        (string.IsNullOrEmpty(country) || a.Address.Country == country) &&
                                        (string.IsNullOrEmpty(location) || a.Address.Street == location))
                            .Select(a => new
                            {
                                a.AttractionID,
                                a.Name,
                                a.Category,
                                a.Description,
                                CommentsCount = a.Comments.Count,
                                a.AddressID,
                                Address = new
                                {
                                    a.Address.AddressID,
                                    a.Address.Street,
                                    a.Address.City,
                                    a.Address.Country,
                                    a.Address.ZipCode
                                }
                            })
                            .ToList();

            return Ok(attractions);
        }

        [HttpGet("Attractions without comments")]
        public IActionResult GetAttractionsWithoutComments()
        {
            var attractions = _context.Attraction
                            .Where(a => !a.Comments.Any())
                            .ToList();

            if (!attractions.Any())
            {
                return Ok("There are no attractions without comments");
            }

            return Ok(attractions);
        }

        [HttpGet("Attraction info {id}")]
        public IActionResult GetAttractionWithComments(Guid id)
        {
            var attraction = _context.Attraction
                            .Include(a => a.Comments)
                            .ThenInclude(c => c.User)
                            .Where(a => a.AttractionID == id)
                            .Select(a => new
                            {
                                a.Category,
                                a.Name,
                                a.Description,
                                Comments = a.Comments.Select(c => new
                                {
                                    c.CommentID,
                                    c.Text,
                                    c.UserID,
                                    User = c.User.UserName,
                                    c.AttractionID,
                                    Attraction = a.Name
                                }).ToList()
                            })
                            .FirstOrDefault();

            if (attraction == null)
            {
                return NotFound();
            }

            return Ok(attraction);
        }

        // I decided to use pagination because after seeding according to the 
        // projects requirments we have about 15000 comments and showing all user comments
        // without pagination takes very long and sometimes crashes the Swagger UI
        [HttpGet("Users and all their comments")]
        public IActionResult GetUsersWithComments(int pageNumber = 1, int pageSize = 10)
        {
            var users = _context.Users
                        .Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize)
                        .Select(u => new
                        {
                            u.UserID,
                            u.UserName,
                            Comments = u.Comments.ToList()
                        })
                        .ToList();
            return Ok(users);
        }

        /* IF YOU WANT TO GET ALL USERS WITH ALL COMMENTS WITHOUT PAGINATION USE THIS, AT YOUR OWN RISK
        [HttpGet("Users and all their comments")]
        public IActionResult GetUsersWithComments()
        {
            var users = _context.Users
                        .Select(u => new
                        {
                            u.UserID,
                            u.UserName,
                            Comments = u.Comments.ToList()
                        })
                        .ToList();
            return Ok(users);
        }
*/

    }
}