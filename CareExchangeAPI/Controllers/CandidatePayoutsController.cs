
using CareExchangeAPI.Data;
using CareExchangeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace CareExchangeAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CandidatePayoutsController(AppDbContext context) : ControllerBase
{
    private readonly AppDbContext _context = context;

    // POST: api/CandidatePayouts
    [HttpPost]
    public async Task<ActionResult<CandidatePayout>> Create([FromBody] CandidatePayout payout)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        _context.CandidatePayouts.Add(payout);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = payout.Id }, payout);
    }

    // GET: api/CandidatePayouts/5 (helper for CreatedAtAction)
    [HttpGet("{id}")]
    public async Task<ActionResult<CandidatePayout>> GetById(int id)
    {
        var payout = await _context.CandidatePayouts
            .Include(p => p.Candidate)
            .Include(p => p.Shift)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (payout == null)
            return NotFound();

        return payout;
    }

    // PUT: api/CandidatePayouts/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] CandidatePayout updatedPayout)
    {
        if (id != updatedPayout.Id)
            return BadRequest("ID mismatch");

        _context.Entry(updatedPayout).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.CandidatePayouts.Any(p => p.Id == id))
                return NotFound();

            throw;
        }

        return NoContent();
    }

    // DELETE: api/CandidatePayouts/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var payout = await _context.CandidatePayouts.FindAsync(id);
        if (payout == null)
            return NotFound();

        _context.CandidatePayouts.Remove(payout);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}