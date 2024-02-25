using AlquileVehiculosWebApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using AlquileVehiculosWebApi.Models;

[Route("api/[controller]")]
[ApiController]
public class TarifasController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public TarifasController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Tarifas
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Tarifas>>> GetTarifas()
    {
        return await _context.Tarifas.ToListAsync();
    }

    // GET: api/Tarifas/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Tarifas>> GetTarifa(int id)
    {
        var tarifa = await _context.Tarifas.FindAsync(id);

        if (tarifa == null)
        {
            return NotFound();
        }

        return tarifa;
    }

    // POST: api/Tarifas
    [HttpPost]
    public async Task<ActionResult<Tarifas>> PostTarifa(Tarifas tarifa)
    {
        _context.Tarifas.Add(tarifa);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTarifa", new { id = tarifa.Id }, tarifa);
    }

    // PUT: api/Tarifas/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTarifa(int id, Tarifas tarifa)
    {
        if (id != tarifa.Id)
        {
            return BadRequest();
        }

        _context.Entry(tarifa).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TarifaExists(id))
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

    // DELETE: api/Tarifas/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTarifa(int id)
    {
        var tarifa = await _context.Tarifas.FindAsync(id);
        if (tarifa == null)
        {
            return NotFound();
        }

        _context.Tarifas.Remove(tarifa);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TarifaExists(int id)
    {
        return _context.Tarifas.Any(e => e.Id == id);
    }
}
