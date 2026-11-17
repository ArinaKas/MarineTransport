using MarineTransport.Api.Enums;

namespace MarineTransport.Api.Models;

public class Incident
{
    public int Id { get; set; }

    public int TripId { get; set; }

    public Trip Trip { get; set; } = null!;

    public IncidentType Type { get; set; }

    public string Description { get; set; } = string.Empty;

    public DateTime DateTime { get; set; }

    public IncidentStatus Status { get; set; } = IncidentStatus.Open;

    public string ResolutionDescription { get; set; } = string.Empty;
}
