namespace MarineTransport.Api.Models;

public class ShipTeam
{
    public int Id { get; set; }

    public int ShipId { get; set; }

    public Ship Ship { get; set; } = null!;

    public DateTime AssignmentDate { get; set; }

    public DateTime? EndDate { get; set; }

    public ICollection<CrewMember> CrewMembers { get; set; }
        = new List<CrewMember>();
}
