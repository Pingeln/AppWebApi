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
    public class UsersController : ControllerBase
    {
        private readonly csMainDbContext _context;

        public UsersController(csMainDbContext context)
        {
            _context = context;
        }

        // GET: api/Users/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<csUserDbM>> GetUser(Guid id)
        {
            var user = await _context.Users
                .Include(u => u.Comments) // Include related Comments
                .FirstOrDefaultAsync(u => u.UserID == id);

            if (user == null)
            {
               return NotFound();
            }

            // Return the user with included comments
            return Ok(user);
        }

        // GET: api/Users/read
        [HttpGet("read")]
        public async Task<ActionResult<IEnumerable<csUserDbM>>> GetUsers()
        {
            var users = await _context.Users.Include(u => u.Comments).ToListAsync();

            if (users == null || users.Count == 0)
            {
                return NotFound();
            }

            return Ok(users);
        }
    }
}
