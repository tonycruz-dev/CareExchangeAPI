
using CareExchangeAPI.Data;
using CareExchangeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace CareExchangeAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientPaymentsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ClientPaymentsController(AppDbContext context)
    {
        _context = context;
    }

    // POST: api/ClientPayments
    [HttpPost]
    public async Task<ActionResult<ClientPayment>> Create([FromBody] ClientPayment payment)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        _context.ClientPayments.Add(payment);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = payment.Id }, payment);
    }

    // GET: api/ClientPayments/5 (helper for CreatedAtAction)
    [HttpGet("{id}")]
    public async Task<ActionResult<ClientPayment>> GetById(int id)
    {
        var payment = await _context.ClientPayments
            .Include(p => p.Client)
            .Include(p => p.Shift)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (payment == null)
            return NotFound();

        return payment;
    }

    // PUT: api/ClientPayments/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] ClientPayment updatedPayment)
    {
        if (id != updatedPayment.Id)
            return BadRequest("ID mismatch");

        _context.Entry(updatedPayment).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.ClientPayments.Any(p => p.Id == id))
                return NotFound();

            throw;
        }

        return NoContent();
    }

    // DELETE: api/ClientPayments/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var payment = await _context.ClientPayments.FindAsync(id);
        if (payment == null)
            return NotFound();

        _context.ClientPayments.Remove(payment);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}