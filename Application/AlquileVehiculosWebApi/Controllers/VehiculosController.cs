using AlquileVehiculosWebApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using AlquileVehiculosWebApi.Models;

[Route("api/[controller]")]
[ApiController]
public class VehiculosController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public VehiculosController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Vehiculos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Vehiculos>>> GetVehiculos()
    {
        return await _context.Vehiculos.ToListAsync();
    }

    // GET: api/Vehiculos/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Vehiculos>> GetVehiculo(int id)
    {
        var vehiculo = await _context.Vehiculos.FindAsync(id);

        if (vehiculo == null)
        {
            return NotFound();
        }

        return vehiculo;
    }

    // POST: api/Vehiculos
    [HttpPost]
    public async Task<ActionResult<Vehiculos>> PostVehiculo(Vehiculos vehiculo)
    {
        _context.Vehiculos.Add(vehiculo);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetVehiculo", new { id = vehiculo.Id }, vehiculo);
    }

    // PUT: api/Vehiculos/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutVehiculo(int id, Vehiculos vehiculo)
    {
        if (id != vehiculo.Id)
        {
            return BadRequest();
        }

        _context.Entry(vehiculo).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!VehiculoExists(id))
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

    // DELETE: api/Vehiculos/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVehiculo(int id)
    {
        var vehiculo = await _context.Vehiculos.FindAsync(id);
        if (vehiculo == null)
        {
            return NotFound();
        }

        _context.Vehiculos.Remove(vehiculo);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool VehiculoExists(int id)
    {
        return _context.Vehiculos.Any(e => e.Id == id);
    }
}
