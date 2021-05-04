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
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class SpecialistsController : ControllerBase
    {
        private readonly DbContextTerapicFisicHelperApp _context;

        public SpecialistsController(DbContextTerapicFisicHelperApp context)
        {
            _context = context;
        }

        // GET: api/Specialists
        [HttpGet]
        public async Task<IEnumerable<SpecialistModel>> GetSpecialists()
        {
            var specialistList = await _context.Specialists.ToListAsync();

            return specialistList.Select(c => new SpecialistModel
            {
                Id = c.Id,
                Specialty = c.Specialty,
                UserId = c.UserId
            });
        }

        // GET: api/Specialists/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpecialistById([FromRoute] int id)
        {
            var spec = await _context.Specialists.FindAsync(id);

            if (spec == null)
            {
                return NotFound();
            }

            return Ok(new SpecialistModel
            {
                Id = spec.Id,
                Specialty = spec.Specialty,
                UserId = spec.UserId
            });
        }

        // POST: api/Specialists
        [HttpPost]
        public async Task<IActionResult> PostSpecialist([FromBody] CreateSpecialistModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Specialist specialist = new Specialist
            {
                Specialty = model.Specialty,
                UserId = model.UserId
            };

            _context.Specialists.Add(specialist);

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
        /*
        // PUT: api/Specialists/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpecialist(int id, Specialist specialist)
        {
            if (id != specialist.Id)
            {
                return BadRequest();
            }

            _context.Entry(specialist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpecialistExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Specialists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpecialist(int id)
        {
            var specialist = await _context.Specialists.FindAsync(id);
            if (specialist == null)
            {
                return NotFound();
            }

            _context.Specialists.Remove(specialist);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SpecialistExists(int id)
        {
            return _context.Specialists.Any(e => e.Id == id);
        }
        */
    }
}
