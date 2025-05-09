
using CareExchangeAPI.Data;
using CareExchangeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace CareExchangeAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ShiftRatesController(AppDbContext context) : ControllerBase
{
    private readonly AppDbContext _context = context;

    // POST: api/ShiftRatings
    [HttpPost]
    public async Task<ActionResult<ShiftRating>> Create([FromBody] ShiftRating rating)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        _context.ShiftRatings.Add(rating);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = rating.Id }, rating);
    }

    // GET: api/ShiftRatings/5 (helper for POST response)
    [HttpGet("{id}")]
    public async Task<ActionResult<ShiftRating>> GetById(int id)
    {
        var rating = await _context.ShiftRatings
            .Include(r => r.Shift)
            .Include(r => r.RatedByUser)
            .Include(r => r.RatedUser)
            .FirstOrDefaultAsync(r => r.Id == id);

        if (rating == null)
            return NotFound();

        return rating;
    }

    // PUT: api/ShiftRatings/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] ShiftRating updatedRating)
    {
        if (id != updatedRating.Id)
            return BadRequest("ID mismatch");

        _context.Entry(updatedRating).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.ShiftRatings.Any(r => r.Id == id))
                return NotFound();

            throw;
        }

        return NoContent();
    }

    // DELETE: api/ShiftRatings/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var rating = await _context.ShiftRatings.FindAsync(id);
        if (rating == null)
            return NotFound();

        _context.ShiftRatings.Remove(rating);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}