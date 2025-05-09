
using CareExchangeAPI.Data;
using CareExchangeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace CareExchangeAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ShiftLogsController(AppDbContext context) : ControllerBase
{
    private readonly AppDbContext _context = context;

    // POST: api/ShiftLogs
    [HttpPost]
    public async Task<ActionResult<ShiftLog>> Create([FromBody] ShiftLog log)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        _context.ShiftLogs.Add(log);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = log.Id }, log);
    }

    // GET: api/ShiftLogs/5 (for CreatedAtAction)
    [HttpGet("{id}")]
    public async Task<ActionResult<ShiftLog>> GetById(int id)
    {
        var log = await _context.ShiftLogs
            .Include(l => l.Shift)
            .Include(l => l.ChangedByUser)
            .FirstOrDefaultAsync(l => l.Id == id);

        if (log == null)
            return NotFound();

        return log;
    }

    // PUT: api/ShiftLogs/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] ShiftLog updatedLog)
    {
        if (id != updatedLog.Id)
            return BadRequest("ID mismatch");

        _context.Entry(updatedLog).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.ShiftLogs.Any(l => l.Id == id))
                return NotFound();

            throw;
        }

        return NoContent();
    }

    // DELETE: api/ShiftLogs/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var log = await _context.ShiftLogs.FindAsync(id);
        if (log == null)
            return NotFound();

        _context.ShiftLogs.Remove(log);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
