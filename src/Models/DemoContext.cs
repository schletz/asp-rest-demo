namespace Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class DemoContext : DbContext
{
    public DbSet<Vehicle> Vehicles { get; set; }
    public DemoContext(DbContextOptions<DemoContext> options) : base(options)
    {
    }

    public async Task Seed()
    {
        // Create a list with 3 vehicles
        var vehicles = new List<Vehicle>
        {
            new Vehicle(brand: "Opel", model: "Kadett"),
            new Vehicle(brand: "VW", model: "Käfer 1400"),
            new Vehicle(brand: "Opel", model: "Blitz"),
            new Vehicle(brand: "VW", model: "eGolf")
        };
        Vehicles.AddRange(vehicles);
        await SaveChangesAsync();
    }
}
