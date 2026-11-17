using MarineTransport.Api.Enums;

namespace MarineTransport.Api.Models;

public class PassengerOperation
{
    public int Id { get; set; }

    public int TripId { get; set; }

    public Trip Trip { get; set; } = null!;

    public int PassengerCount { get; set; }

    public PassengerOperationType OperationType { get; set; }

    public DateTime DateTime { get; set; }
}
