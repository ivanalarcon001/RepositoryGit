using AlquileVehiculosWebApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using AlquileVehiculosWebApi.Models;

[Route("api/[controller]")]
[ApiController]
public class ReservasController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ReservasController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Reservas
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Reservas>>> GetReservas()
    {
        return await _context.Reservas.ToListAsync();
    }

    // GET: api/Reservas/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Reservas>> GetReserva(int id)
    {
        var reserva = await _context.Reservas.FindAsync(id);

        if (reserva == null)
        {
            return NotFound();
        }

        return reserva;
    }

    // POST: api/Reservas
    [HttpPost]
    public async Task<ActionResult<Reservas>> PostReserva(Reservas reserva)
    {
        _context.Reservas.Add(reserva);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetReserva", new { id = reserva.Id }, reserva);
    }

    // PUT: api/Reservas/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutReserva(int id, Reservas reserva)
    {
        if (id != reserva.Id)
        {
            return BadRequest();
        }

        _context.Entry(reserva).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ReservaExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // DELETE: api/Reservas/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteReserva(int id)
    {
        var reserva = await _context.Reservas.FindAsync(id);
        if (reserva == null)
        {
            return NotFound();
        }

        _context.Reservas.Remove(reserva);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ReservaExists(int id)
    {
        return _context.Reservas.Any(e => e.Id == id);
    }
}
