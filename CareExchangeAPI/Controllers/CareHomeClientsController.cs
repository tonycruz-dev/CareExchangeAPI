
using CareExchangeAPI.Data;
using CareExchangeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace CareExchangeAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CareHomeClientsController(AppDbContext context) : ControllerBase
{
    private readonly AppDbContext _context = context;

    // POST: api/CareHomeClients
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CareHomeClient client)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        _context.CareHomeClients.Add(client);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = client.Id }, client);
    }

    // GET: api/CareHomeClients/5
    [HttpGet("{id}")]
    public async Task<ActionResult<CareHomeClient>> GetById(int id)
    {
        var client = await _context.CareHomeClients
            .Include(c => c.Locations)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (client == null)
            return NotFound();

        return client;
    }

    // PUT: api/CareHomeClients/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] CareHomeClient updatedClient)
    {
        if (id != updatedClient.Id)
            return BadRequest("ID mismatch.");

        _context.Entry(updatedClient).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.CareHomeClients.Any(e => e.Id == id))
                return NotFound();

            throw;
        }

        return NoContent();
    }

    // DELETE: api/CareHomeClients/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var client = await _context.CareHomeClients.FindAsync(id);
        if (client == null)
            return NotFound();

        _context.CareHomeClients.Remove(client);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}