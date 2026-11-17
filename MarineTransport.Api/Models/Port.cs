namespace MarineTransport.Api.Models;

public class Port
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Country { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;
}
