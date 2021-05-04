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
    public class EquipamentSessionsController : ControllerBase
    {
        private readonly DbContextTerapicFisicHelperApp _context;

        public EquipamentSessionsController(DbContextTerapicFisicHelperApp context)
        {
            _context = context;
        }

        // GET: api/EquipamentSessions
        [HttpGet]
        public async Task<IEnumerable<EquipamentSessionModel>> GetEquipamentSessions()
        {
            var equipamentSessionList = await _context.EquipamentSessions.ToListAsync();

            return equipamentSessionList.Select(c => new EquipamentSessionModel
            {
                EquipamentId = c.EquipamentId,
                SessionId = c.SessionId
            });
        }

        // POST: api/EquipamentSessions
        [HttpPost]
        public async Task<IActionResult> PostEquipamentSession([FromBody] CreateEquipamentSessionModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            EquipamentSession equipamentSession = new EquipamentSession
            {
                EquipamentId = model.EquipamentId,
                SessionId = model.SessionId
            };

            _context.EquipamentSessions.Add(equipamentSession);

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

        // DELETE: api/EquipamentSessions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipamentSession([FromRoute] int id)
        {
            var equipamentSession = await _context.EquipamentSessions.FindAsync(id);

            if (equipamentSession == null)
                return NotFound();

            _context.EquipamentSessions.Remove(equipamentSession);

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

        // GET: api/GetAllBySessionId/5
        [HttpGet("{GetAllBySessionId}/{id}")]
        public async Task<IActionResult> GetAllBySessionId([FromRoute] int sessionId)
        {
            var equipament = await _context.Equipaments.FindAsync(sessionId);
            
            if (equipament == null)
            {
                return NotFound();
            }

            return Ok(new EquipamentModel
            {
                Id = equipament.Id,
                Name = equipament.Name,
                Description = equipament.Description,
            });
        }

        // GET: api/GetAllByEquipamentId/5
        [HttpGet("{GetAllByEquipamentId}/{id}")]
        public async Task<IActionResult> GetAllByEquipamentId([FromRoute] int equipamentId)
        {
            var session = await _context.Sessions.FindAsync(equipamentId);

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
    }
}
