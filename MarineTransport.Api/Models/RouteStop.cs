namespace MarineTransport.Api.Models;

public class RouteStop
{
    public int Id { get; set; }

    public int RouteId { get; set; }

    public Route Route { get; set; } = null!;

    public int PortId { get; set; }

    public Port Port { get; set; } = null!;

    public int SequenceNumber { get; set; }
}
