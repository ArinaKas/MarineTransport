namespace MarineTransport.Api.Models;

public class Port
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Country { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    public ICollection<RouteStop> RouteStops { get; set; }
        = new List<RouteStop>();
    
    public ICollection<MovementRegistration> MovementRegistrations { get; set; }
        = new List<MovementRegistration>();

}
