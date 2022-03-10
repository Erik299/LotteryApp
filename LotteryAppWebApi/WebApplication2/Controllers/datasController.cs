using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class datasController : ControllerBase
    {
        public void Put(int id, [FromBody] datas data)
        {
            using (slot_machineContext dbContext = new slot_machineContext())
            {
                var entity = dbContext.datas.FirstOrDefault(e => e.id == id);

                entity.name = data.name;
                entity.quantity = data.quantity;
                entity.value = data.value;
                entity.picture = data.picture;
                entity.logo = data.logo;

                dbContext.SaveChanges();
            }
        }
        private readonly slot_machineContext _context;

        public datasController(slot_machineContext context)
        {
            _context = context;
        }

        // GET: api/datas
        [HttpGet]
        [EnableCors("CorsPolicy")]
        public async Task<ActionResult<IEnumerable<datas>>> Getdatas()
        {
            return await _context.datas.ToListAsync();
        }

        // GET: api/datas/5
        [HttpGet("{id}")]
        [EnableCors("CorsPolicy")]
        public async Task<ActionResult<datas>> Getdatas(sbyte id)
        {
            var datas = await _context.datas.FindAsync(id);

            if (datas == null)
            {
                return NotFound();
            }

            return datas;
        }

        // PUT: api/datas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [EnableCors("CorsPolicy")]
        public async Task<IActionResult> Putdatas(sbyte id, datas datas)
        {
            if (id != datas.id)
            {
                return BadRequest();
            }

            _context.Entry(datas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!datasExists(id))
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

        // POST: api/datas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [EnableCors("CorsPolicy")]
        public async Task<ActionResult<datas>> Postdatas(datas datas)
        {
            _context.datas.Add(datas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getdatas", new { id = datas.id }, datas);
        }

        // DELETE: api/datas/5
        [HttpDelete("{id}")]
        [EnableCors("CorsPolicy")]
        public async Task<IActionResult> Deletedatas(sbyte id)
        {
            var datas = await _context.datas.FindAsync(id);
            if (datas == null)
            {
                return NotFound();
            }

            _context.datas.Remove(datas);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool datasExists(sbyte id)
        {
            return _context.datas.Any(e => e.id == id);
        }
    }
}
