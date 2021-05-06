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
    public class TagsController : ControllerBase
    {
        private readonly DbContextTerapicFisicHelperApp _context;

        public TagsController(DbContextTerapicFisicHelperApp context)
        {
            _context = context;
        }

        // GET: api/Tags
        [HttpGet]
        public async Task<IEnumerable<TagModel>> GetTags()
        {
            var tagList = await _context.Tags.ToListAsync();

            return tagList.Select(c => new TagModel
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description
            });
        }

        // GET: api/Tags/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTagById([FromRoute] int id)
        {
            var tag = await _context.Tags.FindAsync(id);

            if (tag == null)
            {
                return NotFound();
            }

            return Ok(new TagModel
            {
                Id = tag.Id,
                Name = tag.Name,
                Description = tag.Description
            });
        }

        // POST: api/Tags
        [HttpPost]
        public async Task<IActionResult> PostTag([FromBody] CreateTagModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Tag tag = new Tag
            {
                Name = model.Name,
                Description = model.Description
            };

            _context.Tags.Add(tag);

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

        // PUT: api/Tags/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTag([FromBody] UpdateTagModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (model.Id <= 0)
                return BadRequest();

            var tag = await _context.Tags.FirstOrDefaultAsync(c => c.Id == model.Id);

            if (tag == null)
                return NotFound();

            tag.Name = model.Name;
            tag.Description = model.Description;

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

        // DELETE: api/Tags/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTag([FromRoute] int id)
        {
            var tag = await _context.Tags.FindAsync(id);

            if (tag == null)
                return NotFound();

            _context.Tags.Remove(tag);

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
