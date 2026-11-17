namespace MarineTransport.Api.Models;

public class TransportReport
{
    public int Id { get; set; }

    public DateTime PeriodStart { get; set; }

    public DateTime PeriodEnd { get; set; }

    public DateTime GeneratedAt { get; set; } = DateTime.UtcNow;

    public string ReportData { get; set; } = string.Empty;
}
