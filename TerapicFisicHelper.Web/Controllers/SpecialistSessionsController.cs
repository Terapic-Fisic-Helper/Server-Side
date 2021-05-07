using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TerapicFisicHelper.Data;
using TerapicFisicHelper.Entities;
using TerapicFisicHelper.Web.Models;

namespace TerapicFisicHelper.Web.Controllers
{
    [ApiController]
    [Route("api/specialists/{specialistId}/sessions")]
    [Produces("application/json")]
    public class SpecialistSessionsController : ControllerBase
    {
        private readonly DbContextTerapicFisicHelperApp _context;

        public SpecialistSessionsController(DbContextTerapicFisicHelperApp context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBySpecialistIdAsync(int specialistId)
        {
            var session = await _context.Sessions.FindAsync(specialistId);

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
                EndHour = session.EndHour,
            });
        }
    }
}
