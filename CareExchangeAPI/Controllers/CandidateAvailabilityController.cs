
using CareExchangeAPI.Data;
using CareExchangeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace CareExchangeAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CandidateAvailabilitiesController(AppDbContext context) : ControllerBase
{
    private readonly AppDbContext _context = context;

    // POST: api/CandidateAvailability
    [HttpPost]
    public async Task<ActionResult<CandidateAvailability>> Create([FromBody] CandidateAvailability availability)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        _context.CandidateAvailabilities.Add(availability);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = availability.Id }, availability);
    }

    // GET: api/CandidateAvailability/5 (for CreatedAtAction)
    [HttpGet("{id}")]
    public async Task<ActionResult<CandidateAvailability>> GetById(int id)
    {
        var availability = await _context.CandidateAvailabilities
            .Include(a => a.Candidate)
            .FirstOrDefaultAsync(a => a.Id == id);

        if (availability == null)
            return NotFound();

        return availability;
    }

    // PUT: api/CandidateAvailability/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] CandidateAvailability updatedAvailability)
    {
        if (id != updatedAvailability.Id)
            return BadRequest("ID mismatch");

        _context.Entry(updatedAvailability).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.CandidateAvailabilities.Any(a => a.Id == id))
                return NotFound();

            throw;
        }

        return NoContent();
    }

    // DELETE: api/CandidateAvailability/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var availability = await _context.CandidateAvailabilities.FindAsync(id);
        if (availability == null)
            return NotFound();

        _context.CandidateAvailabilities.Remove(availability);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}