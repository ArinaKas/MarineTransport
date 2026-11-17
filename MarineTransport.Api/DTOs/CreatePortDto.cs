namespace MarineTransport.Api.DTOs;

public class CreatePortDto
{
    public string Name { get; set; } = string.Empty;

    public string Country { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;
}
