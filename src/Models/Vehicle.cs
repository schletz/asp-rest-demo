namespace Models;

public class Vehicle
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public Vehicle() {}
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public Vehicle(string brand, string model)
    {
        Brand = brand;
        Model = model;
    }

    public int Id { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
}

