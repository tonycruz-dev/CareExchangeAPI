
using CareExchangeAPI.Data;
using CareExchangeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace CareExchangeAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MessagesController(AppDbContext context) : ControllerBase
{
    private readonly AppDbContext _context = context;

    // POST: api/Messages
    [HttpPost]
    public async Task<ActionResult<Message>> Create([FromBody] Message message)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        _context.Messages.Add(message);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = message.Id }, message);
    }

    // GET: api/Messages/5 (helper for CreatedAtAction)
    [HttpGet("{id}")]
    public async Task<ActionResult<Message>> GetById(int id)
    {
        var message = await _context.Messages
            .Include(m => m.Sender)
            .Include(m => m.Receiver)
            .FirstOrDefaultAsync(m => m.Id == id);

        if (message == null)
            return NotFound();

        return message;
    }

    // PUT: api/Messages/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Message updatedMessage)
    {
        if (id != updatedMessage.Id)
            return BadRequest("ID mismatch");

        _context.Entry(updatedMessage).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Messages.Any(m => m.Id == id))
                return NotFound();

            throw;
        }

        return NoContent();
    }

    // DELETE: api/Messages/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var message = await _context.Messages.FindAsync(id);
        if (message == null)
            return NotFound();

        _context.Messages.Remove(message);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}