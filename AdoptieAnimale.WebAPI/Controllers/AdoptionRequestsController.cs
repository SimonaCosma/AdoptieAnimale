using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdoptieAnimale.WebAPI.Data;
using AdoptieAnimale.WebAPI.Models;

namespace AdoptieAnimale.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdoptionRequestsController : ControllerBase
    {
        private readonly AdoptieAnimaleContext _context;

        public AdoptionRequestsController(AdoptieAnimaleContext context)
        {
            _context = context;
        }

        // GET: api/AdoptionRequests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdoptionRequest>>> GetAdoptionRequests()
        {
            return await _context.AdoptionRequests.ToListAsync();
        }

        // GET: api/AdoptionRequests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AdoptionRequest>> GetAdoptionRequest(int id)
        {
            var adoptionRequest = await _context.AdoptionRequests.FindAsync(id);

            if (adoptionRequest == null)
            {
                return NotFound();
            }

            return adoptionRequest;
        }

        // PUT: api/AdoptionRequests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdoptionRequest(int id, AdoptionRequest adoptionRequest)
        {
            if (id != adoptionRequest.ID)
            {
                return BadRequest();
            }

            _context.Entry(adoptionRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdoptionRequestExists(id))
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

        // POST: api/AdoptionRequests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AdoptionRequest>> PostAdoptionRequest(AdoptionRequest adoptionRequest)
        {
            _context.AdoptionRequests.Add(adoptionRequest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdoptionRequest", new { id = adoptionRequest.ID }, adoptionRequest);
        }

        // DELETE: api/AdoptionRequests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdoptionRequest(int id)
        {
            var adoptionRequest = await _context.AdoptionRequests.FindAsync(id);
            if (adoptionRequest == null)
            {
                return NotFound();
            }

            _context.AdoptionRequests.Remove(adoptionRequest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdoptionRequestExists(int id)
        {
            return _context.AdoptionRequests.Any(e => e.ID == id);
        }
    }
}
