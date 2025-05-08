using CareExchangeAPI.Data;
using CareExchangeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CareExchangeAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ShiftsController(AppDbContext context) : ControllerBase
{
    private readonly AppDbContext _context = context;

    // POST: api/Shifts
    [HttpPost]
    public async Task<ActionResult<Shift>> Create([FromBody] Shift shift)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        _context.Shifts.Add(shift);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = shift.Id }, shift);
    }

    // Helper GET for CreatedAtAction
    [HttpGet("{id}")]
    public async Task<ActionResult<Shift>> GetById(int id)
    {
        var shift = await _context.Shifts
            .Include(s => s.Location)
            .Include(s => s.JobType)
            .Include(s => s.CreatedByClientUser)
            .FirstOrDefaultAsync(s => s.Id == id);

        if (shift == null)
            return NotFound();

        return shift;
    }

    // PUT: api/Shifts/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Shift shift)
    {
        if (id != shift.Id)
            return BadRequest("Shift ID mismatch.");

        _context.Entry(shift).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Shifts.Any(s => s.Id == id))
                return NotFound();

            throw;
        }

        return NoContent();
    }

    // DELETE: api/Shifts/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var shift = await _context.Shifts.FindAsync(id);
        if (shift == null)
            return NotFound();

        _context.Shifts.Remove(shift);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}