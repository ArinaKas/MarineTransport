using MarineTransport.Api.Enums;

namespace MarineTransport.Api.Models;

public class CrewMember
{
    public int Id { get; set; }

    public string LastName { get; set; } = string.Empty;

    public string FirstName { get; set; } = string.Empty;

    public string Position { get; set; } = string.Empty;

    public string DocumentNumber { get; set; } = string.Empty;

    public CrewMemberStatus Status { get; set; } =
        CrewMemberStatus.Available;
}
