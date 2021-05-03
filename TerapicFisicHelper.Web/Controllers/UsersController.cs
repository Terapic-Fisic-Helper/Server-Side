using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TerapicFisicHelper.Data;
using TerapicFisicHelper.Entities;
using TerapicFisicHelper.Web.Models;

namespace TerapicFisicHelper.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class UsersController : ControllerBase
    {
        private readonly DbContextTerapicFisicHelperApp _context;

        public UsersController(DbContextTerapicFisicHelperApp context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<IEnumerable<UserModel>> GetUsers()
        {
            var userList = await _context.Users.ToListAsync();

            return userList.Select(c => new UserModel
            {
                Id = c.Id,
                Name = c.Name,
                LastName = c.LastName,
                Description = c.Description,
                Birth = c.Birth,
                Address = c.Address,
                Phone = c.Phone,
                Age = c.Age,
                Email = c.Email,
                Country = c.Country,
                Gender = c.Gender,
                Password = c.Password
            });
        }

        // GET: api/Users/GetCategory/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById([FromRoute] int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(new UserModel
            {
                Id = user.Id,
                Name = user.Name,
                LastName = user.LastName,
                Description = user.Description,
                Birth = user.Birth,
                Address = user.Address,
                Phone = user.Phone,
                Age = user.Age,
                Email = user.Email,
                Country = user.Country,
                Gender = user.Gender,
                Password = user.Password
            });
        }

        // POST: api/Users
        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] CreateUserModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            User user = new User
            {
                Name = model.Name,
                LastName = model.LastName,
                Description = model.Description,
                Birth = model.Birth,
                Address = model.Address,
                Phone = model.Phone,
                Age = model.Age,
                Email = model.Email,
                Country = model.Country,
                Gender = model.Gender,
                Password = model.Password
            };

            _context.Users.Add(user);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser([FromBody] UpdateUserModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (model.Id <= 0)
                return BadRequest();

            var user = await _context.Users.FirstOrDefaultAsync(c => c.Id == model.Id);

            if (user == null)
                return NotFound();

            user.Name = model.Name;
            user.LastName = model.LastName;
            user.Description = model.Description;
            user.Birth = model.Birth;
            user.Address = model.Address;
            user.Phone = model.Phone;
            user.Age = model.Age;
            user.Email = model.Email;
            user.Country = model.Country;
            user.Gender = model.Gender;
            user.Password = model.Password;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
                return NotFound();

            _context.Users.Remove(user);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }
    }
}
