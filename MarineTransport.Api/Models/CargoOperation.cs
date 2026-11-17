using MarineTransport.Api.Enums;

namespace MarineTransport.Api.Models;

public class CargoOperation
{
    public int Id { get; set; }

    public int TripId { get; set; }

    public Trip Trip { get; set; } = null!;

    public string CargoName { get; set; } = string.Empty;

    public decimal Quantity { get; set; }

    public string Unit { get; set; } = string.Empty;

    public CargoOperationType OperationType { get; set; }

    public DateTime DateTime { get; set; }
}
