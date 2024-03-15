using Microsoft.AspNetCore.Mvc;
using Models;
using System.Collections.Generic;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
public class VehiclesController : ControllerBase
{
    public record NewVehicleCmd(string Brand, string Model);
    private readonly DemoContext _db;

    public VehiclesController(DemoContext db)
    {
        _db = db;
    }

    [HttpGet]
    public ActionResult<List<Vehicle>> GetAllVehicles()
    {
        var vehicles = _db.Vehicles.ToList();
        return Ok(vehicles);
    }
    [HttpPost]
    public IActionResult AddVehicle(NewVehicleCmd cmd)
    {
        var vehicle = new Vehicle(brand: cmd.Brand, model: cmd.Model);
        _db.Vehicles.Add(vehicle);
        _db.SaveChanges();
        return CreatedAtAction(nameof(AddVehicle), new { Id = vehicle.Id });
    }
}