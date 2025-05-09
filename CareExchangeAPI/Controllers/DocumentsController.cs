
using CareExchangeAPI.Data;
using CareExchangeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace CareExchangeAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DocumentsController(AppDbContext context) : ControllerBase
{
    private readonly AppDbContext _context = context;

    // POST: api/Documents
    [HttpPost]
    public async Task<ActionResult<Document>> Create([FromBody] Document document)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        _context.Documents.Add(document);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = document.Id }, document);
    }

    // GET: api/Documents/5 (helper for POST response)
    [HttpGet("{id}")]
    public async Task<ActionResult<Document>> GetById(int id)
    {
        var document = await _context.Documents.FindAsync(id);
        if (document == null)
            return NotFound();

        return document;
    }

    // PUT: api/Documents/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Document updatedDocument)
    {
        if (id != updatedDocument.Id)
            return BadRequest("ID mismatch");

        _context.Entry(updatedDocument).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Documents.Any(d => d.Id == id))
                return NotFound();

            throw;
        }

        return NoContent();
    }

    // DELETE: api/Documents/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var document = await _context.Documents.FindAsync(id);
        if (document == null)
            return NotFound();

        _context.Documents.Remove(document);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
