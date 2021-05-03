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
    public class CustomersController : ControllerBase
    {
        private readonly DbContextTerapicFisicHelperApp _context;

        public CustomersController(DbContextTerapicFisicHelperApp context)
        {
            _context = context;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<IEnumerable<CustomerModel>> GetCustomers()
        {
            var customerList = await _context.Customers.ToListAsync();

            return customerList.Select(c => new CustomerModel
            {
                Id = c.Id,
                Description = c.Description,
                UserId = c.UserId
            });
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById([FromRoute] int id)
        {
            var cust = await _context.Customers.FindAsync(id);

            if (cust == null)
            {
                return NotFound();
            }

            return Ok(new CustomerModel
            {
                Id = cust.Id,
                Description = cust.Description,
                UserId = cust.UserId
            });
        }

        // POST: api/Customers
        [HttpPost]
        public async Task<IActionResult> PostCustomer([FromBody] CreateCustomerModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Customer customer = new Customer
            {
                Description = model.Description,
                UserId = model.UserId
            };

            _context.Customers.Add(customer);

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

        // PUT: api/Customers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer([FromBody] UpdateCustomerModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (model.Id <= 0)
                return BadRequest();

            var cust = await _context.Customers.FirstOrDefaultAsync(c => c.Id == model.Id);

            if (cust == null)
                return NotFound();

            cust.Description = model.Description;
            cust.UserId = model.UserId;

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

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var cust = await _context.Customers.FindAsync(id);

            if (cust == null)
                return NotFound();

            _context.Customers.Remove(cust);

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
