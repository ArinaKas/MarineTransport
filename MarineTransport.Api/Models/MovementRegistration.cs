using MarineTransport.Api.Enums;

namespace MarineTransport.Api.Models;

public class MovementRegistration
{
    public int Id { get; set; }

    public int TripId { get; set; }

    public Trip Trip { get; set; } = null!;

    public int PortId { get; set; }

    public Port Port { get; set; } = null!;

    public MovementEventType EventType { get; set; }

    public DateTime DateTime { get; set; }

    public string Comment { get; set; } = string.Empty;
}
