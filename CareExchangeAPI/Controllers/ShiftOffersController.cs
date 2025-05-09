
using CareExchangeAPI.Data;
using CareExchangeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace CareExchangeAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ShiftOffersController(AppDbContext context) : ControllerBase
{
    private readonly AppDbContext _context = context;

    // POST: api/ShiftOffers
    [HttpPost]
    public async Task<ActionResult<ShiftOffer>> Create([FromBody] ShiftOffer offer)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        _context.ShiftOffers.Add(offer);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = offer.Id }, offer);
    }

    // GET: api/ShiftOffers/5 (helper for CreatedAtAction)
    [HttpGet("{id}")]
    public async Task<ActionResult<ShiftOffer>> GetById(int id)
    {
        var offer = await _context.ShiftOffers
            .Include(o => o.Shift)
            .Include(o => o.Candidate)
            .FirstOrDefaultAsync(o => o.Id == id);

        if (offer == null)
            return NotFound();

        return offer;
    }

    // PUT: api/ShiftOffers/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] ShiftOffer updatedOffer)
    {
        if (id != updatedOffer.Id)
            return BadRequest("ID mismatch");

        _context.Entry(updatedOffer).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.ShiftOffers.Any(o => o.Id == id))
                return NotFound();

            throw;
        }

        return NoContent();
    }

    // DELETE: api/ShiftOffers/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var offer = await _context.ShiftOffers.FindAsync(id);
        if (offer == null)
            return NotFound();

        _context.ShiftOffers.Remove(offer);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}