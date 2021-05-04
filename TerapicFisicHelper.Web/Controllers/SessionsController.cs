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
    [Route("api/[controller]")]
    [ApiController]
    public class SessionsController : ControllerBase
    {
        private readonly DbContextTerapicFisicHelperApp _context;

        public SessionsController(DbContextTerapicFisicHelperApp context)
        {
            _context = context;
        }

        // GET: api/Sessions
        [HttpGet]
        public async Task<IEnumerable<SessionModel>> GetSessions()
        {
            var sessionList = await _context.Sessions.ToListAsync();

            return sessionList.Select(c => new SessionModel
            {
                Id = c.Id,
                SpecialistId = c.SpecialistId,
                Title = c.Title,
                Description = c.Description,
                StartDate = c.StartDate,
                StartHour = c.StartHour,
                EndHour = c.EndHour
            });
        }

        // GET: api/Sessions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSessionById(int id)
        {
            var session = await _context.Sessions.FindAsync(id);

            if (session == null)
            {
                return NotFound();
            }

            return Ok(new SessionModel
            {
                Id = session.Id,
                SpecialistId = session.SpecialistId,
                Title = session.Title,
                Description = session.Description,
                StartDate = session.StartDate,
                StartHour = session.StartHour,
                EndHour = session.EndHour
            });
        }

        // POST: api/Sessions
        [HttpPost]
        public async Task<IActionResult> PostSession([FromBody] CreateSessionModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Session session = new Session
            {
                SpecialistId = model.SpecialistId,
                Title = model.Title,
                Description = model.Description,
                StartDate = model.StartDate,
                StartHour = model.StartHour,
                EndHour = model.EndHour
            };

            _context.Sessions.Add(session);

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

        // PUT: api/Sessions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSession([FromBody] UpdateSessionModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (model.Id <= 0)
                return BadRequest();

            var session = await _context.Sessions.FirstOrDefaultAsync(c => c.Id == model.Id);

            if (session == null)
                return NotFound();

            session.SpecialistId = model.SpecialistId;
            session.Title = model.Title;
            session.Description = model.Description;
            session.StartDate = model.StartDate;
            session.StartHour = model.StartHour;
            session.EndHour = model.EndHour;

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

        // DELETE: api/Sessions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSession([FromRoute] int id)
        {
            var session = await _context.Sessions.FindAsync(id);

            if (session == null)
                return NotFound();

            _context.Sessions.Remove(session);

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
