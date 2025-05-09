
using CareExchangeAPI.Data;
using CareExchangeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace CareExchangeAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TimesheetsController(AppDbContext context) : ControllerBase
{
    private readonly AppDbContext _context = context;

    // POST: api/Timesheets
    [HttpPost]
    public async Task<ActionResult<Timesheet>> Create([FromBody] Timesheet timesheet)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        _context.Timesheets.Add(timesheet);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = timesheet.Id }, timesheet);
    }

    // GET: api/Timesheets/5 (helper for CreatedAtAction)
    [HttpGet("{id}")]
    public async Task<ActionResult<Timesheet>> GetById(int id)
    {
        var timesheet = await _context.Timesheets
            .Include(t => t.Shift)
            .Include(t => t.Candidate)
            .Include(t => t.Client)
            .FirstOrDefaultAsync(t => t.Id == id);

        if (timesheet == null)
            return NotFound();

        return timesheet;
    }

    // PUT: api/Timesheets/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Timesheet updatedTimesheet)
    {
        if (id != updatedTimesheet.Id)
            return BadRequest("ID mismatch");

        _context.Entry(updatedTimesheet).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Timesheets.Any(t => t.Id == id))
                return NotFound();

            throw;
        }

        return NoContent();
    }

    // DELETE: api/Timesheets/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var timesheet = await _context.Timesheets.FindAsync(id);
        if (timesheet == null)
            return NotFound();

        _context.Timesheets.Remove(timesheet);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}