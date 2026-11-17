using MarineTransport.Api.Enums;

namespace MarineTransport.Api.Models;

public class Ship
{
    public int Id { get; set; }

    public string RegistrationNumber { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public ShipType ShipType { get; set; }

    public decimal CargoCapacity { get; set; }

    public int PassengerCapacity { get; set; }

    public ShipStatus Status { get; set; } = ShipStatus.Available;
}
