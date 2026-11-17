using MarineTransport.Api.Enums;

namespace MarineTransport.Api.Models;

public class Trip
{
    public int Id { get; set; }

    public string Number { get; set; } = string.Empty;

    public int ShipId { get; set; }

    public Ship Ship { get; set; } = null!;

    public int RouteId { get; set; }

    public Route Route { get; set; } = null!;

    public int? CaptainId { get; set; }

    public User? Captain { get; set; }

    public DateTime DepartureDateTime { get; set; }

    public DateTime PlannedArrivalDateTime { get; set; }

    public DateTime? ActualArrivalDateTime { get; set; }

    public TripType TripType { get; set; }

    public TripStatus Status { get; set; } = TripStatus.Planned;


    public ICollection<MovementRegistration> MovementRegistrations { get; set; }
        = new List<MovementRegistration>();

    public ICollection<CargoOperation> CargoOperations { get; set; }
        = new List<CargoOperation>();

    public ICollection<PassengerOperation> PassengerOperations { get; set; }
        = new List<PassengerOperation>();

    public ICollection<Incident> Incidents { get; set; }
        = new List<Incident>();

}
