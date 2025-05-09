
using CareExchangeAPI.Data;
using CareExchangeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace CareExchangeAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CandidateDocumentsController(AppDbContext context) : ControllerBase
{
    private readonly AppDbContext _context = context;

    // POST: api/CandidateDocuments
    [HttpPost]
    public async Task<ActionResult<CandidateDocument>> Create([FromBody] CandidateDocument doc)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        _context.CandidateDocuments.Add(doc);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = doc.CandidateDocID }, doc);
    }

    // GET: api/CandidateDocuments/5 (helper for CreatedAtAction)
    [HttpGet("{id}")]
    public async Task<ActionResult<CandidateDocument>> GetById(int id)
    {
        var doc = await _context.CandidateDocuments
            .Include(d => d.Candidate)
            .Include(d => d.Document)
            .Include(d => d.Reviewer)
            .FirstOrDefaultAsync(d => d.CandidateDocID == id);

        if (doc == null)
            return NotFound();

        return doc;
    }

    // PUT: api/CandidateDocuments/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] CandidateDocument updatedDoc)
    {
        if (id != updatedDoc.CandidateDocID)
            return BadRequest("ID mismatch");

        _context.Entry(updatedDoc).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.CandidateDocuments.Any(d => d.CandidateDocID == id))
                return NotFound();

            throw;
        }

        return NoContent();
    }

    // DELETE: api/CandidateDocuments/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var doc = await _context.CandidateDocuments.FindAsync(id);
        if (doc == null)
            return NotFound();

        _context.CandidateDocuments.Remove(doc);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
