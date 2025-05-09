
using CareExchangeAPI.Data;
using CareExchangeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace CareExchangeAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CalendarEventsController(AppDbContext context) : ControllerBase
{
    private readonly AppDbContext _context = context;

    // POST: api/CalendarEvents
    [HttpPost]
    public async Task<ActionResult<CalendarEvent>> Create([FromBody] CalendarEvent calendarEvent)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        _context.CalendarEvents.Add(calendarEvent);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = calendarEvent.Id }, calendarEvent);
    }

    // GET: api/CalendarEvents/5 (helper for CreatedAtAction)
    [HttpGet("{id}")]
    public async Task<ActionResult<CalendarEvent>> GetById(int id)
    {
        var calendarEvent = await _context.CalendarEvents
            .Include(e => e.User)
            .Include(e => e.Shift)
            .FirstOrDefaultAsync(e => e.Id == id);

        if (calendarEvent == null)
            return NotFound();

        return calendarEvent;
    }

    // PUT: api/CalendarEvents/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] CalendarEvent updatedEvent)
    {
        if (id != updatedEvent.Id)
            return BadRequest("ID mismatch");

        _context.Entry(updatedEvent).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.CalendarEvents.Any(e => e.Id == id))
                return NotFound();

            throw;
        }

        return NoContent();
    }

    // DELETE: api/CalendarEvents/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var calendarEvent = await _context.CalendarEvents.FindAsync(id);
        if (calendarEvent == null)
            return NotFound();

        _context.CalendarEvents.Remove(calendarEvent);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}