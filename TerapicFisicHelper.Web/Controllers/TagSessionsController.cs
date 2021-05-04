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
    public class TagSessionsController : ControllerBase
    {
        private readonly DbContextTerapicFisicHelperApp _context;

        public TagSessionsController(DbContextTerapicFisicHelperApp context)
        {
            _context = context;
        }

        // GET: api/TagSessions
        [HttpGet]
        public async Task<IEnumerable<TagSessionModel>> GetTagSessions()
        {
            var tagsessionList = await _context.TagSessions.ToListAsync();

            return tagsessionList.Select(c => new TagSessionModel
            {
                TagId = c.TagId,
                SessionId = c.SessionId
            });
        }

        // POST: api/TagSessions
        [HttpPost]
        public async Task<IActionResult> PostTagSession(CreateTagSessionModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            TagSession tagsession = new TagSession
            {
                TagId = model.TagId,
                SessionId = model.SessionId
            };

            _context.TagSessions.Add(tagsession);

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

        [HttpGet("sessions/{sessionId}")]
        public async Task<IActionResult> GetAllBySessionIdAsync(int sessionId)
        {
            var tag = await _context.Sessions.FindAsync(sessionId);

            if (tag == null)
            {
                return NotFound();
            }

            return Ok(new SessionModel
            {
                Id = tag.Id,
                SpecialistId = tag.SpecialistId,
                Title = tag.Title,
                Description = tag.Description,
                StartDate = tag.StartDate,
                StartHour = tag.StartHour,
                EndHour = tag.EndHour
            });
        }

        [HttpGet("tags/{tagId}")]
        public async Task<IActionResult> GetAllByTagIdAsync(int tagId)
        {
            var sessions = await _context.Tags.FindAsync(tagId);

            if (sessions == null)
            {
                return NotFound();
            }

            return Ok(new TagModel
            {
                Id = sessions.Id,
                Name = sessions.Name,
                Description = sessions.Description
            });
        }
    }
}
