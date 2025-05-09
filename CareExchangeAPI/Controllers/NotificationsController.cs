
using CareExchangeAPI.Data;
using CareExchangeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace CareExchangeAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NotificationsController(AppDbContext context) : ControllerBase
{
    private readonly AppDbContext _context = context;

    // POST: api/Notifications
    [HttpPost]
    public async Task<ActionResult<Notification>> Create([FromBody] Notification notification)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        _context.Notifications.Add(notification);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = notification.Id }, notification);
    }

    // GET: api/Notifications/5 (helper for CreatedAtAction)
    [HttpGet("{id}")]
    public async Task<ActionResult<Notification>> GetById(int id)
    {
        var notification = await _context.Notifications
            .Include(n => n.User)
            .FirstOrDefaultAsync(n => n.Id == id);

        if (notification == null)
            return NotFound();

        return notification;
    }

    // PUT: api/Notifications/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Notification updatedNotification)
    {
        if (id != updatedNotification.Id)
            return BadRequest("ID mismatch");

        _context.Entry(updatedNotification).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Notifications.Any(n => n.Id == id))
                return NotFound();

            throw;
        }

        return NoContent();
    }

    // DELETE: api/Notifications/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var notification = await _context.Notifications.FindAsync(id);
        if (notification == null)
            return NotFound();

        _context.Notifications.Remove(notification);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}