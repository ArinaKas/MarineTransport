using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MarineTransport.Api.Data;
using MarineTransport.Api.DTOs;
using MarineTransport.Api.Models;

namespace MarineTransport.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PortsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public PortsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Получение всех портов
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PortDto>>> GetPorts()
    {
        var ports = await _context.Ports
            .Select(port => new PortDto
            {
                Id = port.Id,
                Name = port.Name,
                Country = port.Country,
                Address = port.Address
            })
            .ToListAsync();

        return Ok(ports);
    }

    // Получение одного порта по ID
    [HttpGet("{id}")]
    public async Task<ActionResult<PortDto>> GetPort(int id)
    {
        var port = await _context.Ports
            .Where(port => port.Id == id)
            .Select(port => new PortDto
            {
                Id = port.Id,
                Name = port.Name,
                Country = port.Country,
                Address = port.Address
            })
            .FirstOrDefaultAsync();

        if (port == null)
        {
            return NotFound();
        }

        return Ok(port);
    }

    // Добавление нового порта
    [HttpPost]
    public async Task<ActionResult<PortDto>> CreatePort(
        CreatePortDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Name) ||
            string.IsNullOrWhiteSpace(dto.Country) ||
            string.IsNullOrWhiteSpace(dto.Address))
        {
            return BadRequest("Все поля должны быть заполнены.");
        }

        var port = new Port
        {
            Name = dto.Name,
            Country = dto.Country,
            Address = dto.Address
        };

        _context.Ports.Add(port);

        await _context.SaveChangesAsync();

        var result = new PortDto
        {
            Id = port.Id,
            Name = port.Name,
            Country = port.Country,
            Address = port.Address
        };

        return CreatedAtAction(
            nameof(GetPort),
            new { id = port.Id },
            result);
    }

    // Изменение существующего порта
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePort(
        int id,
        CreatePortDto dto)
    {
        var port = await _context.Ports.FindAsync(id);

        if (port == null)
        {
            return NotFound();
        }

        if (string.IsNullOrWhiteSpace(dto.Name) ||
            string.IsNullOrWhiteSpace(dto.Country) ||
            string.IsNullOrWhiteSpace(dto.Address))
        {
            return BadRequest("Все поля должны быть заполнены.");
        }

        port.Name = dto.Name;
        port.Country = dto.Country;
        port.Address = dto.Address;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    // Удаление порта
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePort(int id)
    {
        var port = await _context.Ports.FindAsync(id);

        if (port == null)
        {
            return NotFound();
        }

        _context.Ports.Remove(port);

        await _context.SaveChangesAsync();

        return NoContent();
    }
}
