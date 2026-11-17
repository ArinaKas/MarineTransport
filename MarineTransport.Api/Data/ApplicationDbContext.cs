using Microsoft.EntityFrameworkCore;
using MarineTransport.Api.Models;
using Route = MarineTransport.Api.Models.Route;


namespace MarineTransport.Api.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();

    public DbSet<Ship> Ships => Set<Ship>();

    public DbSet<Port> Ports => Set<Port>();

    public DbSet<CrewMember> CrewMembers => Set<CrewMember>();

    public DbSet<ShipTeam> ShipTeams => Set<ShipTeam>();

    public DbSet<Route> Routes => Set<Route>();

    public DbSet<RouteStop> RouteStops => Set<RouteStop>();

    public DbSet<Trip> Trips => Set<Trip>();

    public DbSet<MovementRegistration> MovementRegistrations
        => Set<MovementRegistration>();

    public DbSet<CargoOperation> CargoOperations
        => Set<CargoOperation>();

    public DbSet<PassengerOperation> PassengerOperations
        => Set<PassengerOperation>();

    public DbSet<Incident> Incidents => Set<Incident>();

    public DbSet<TransportReport> TransportReports
        => Set<TransportReport>();

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Уникальный регистрационный номер судна
        modelBuilder.Entity<Ship>()
            .HasIndex(s => s.RegistrationNumber)
            .IsUnique();

        // Уникальный номер рейса
        modelBuilder.Entity<Trip>()
            .HasIndex(t => t.Number)
            .IsUnique();

        // В одном маршруте не может быть двух остановок
        // с одинаковым порядковым номером
        modelBuilder.Entity<RouteStop>()
            .HasIndex(rs => new { rs.RouteId, rs.SequenceNumber })
            .IsUnique();

        // Судно и судовые команды: один ко многим
        modelBuilder.Entity<ShipTeam>()
            .HasOne(st => st.Ship)
            .WithMany(s => s.Teams)
            .HasForeignKey(st => st.ShipId)
            .OnDelete(DeleteBehavior.Restrict);

        // Судовые команды и члены экипажа: многие ко многим
        modelBuilder.Entity<ShipTeam>()
            .HasMany(st => st.CrewMembers)
            .WithMany()
            .UsingEntity(j => j.ToTable("ShipTeamCrewMembers"));

        // Судно и рейсы: один ко многим
        modelBuilder.Entity<Trip>()
            .HasOne(t => t.Ship)
            .WithMany(s => s.Trips)
            .HasForeignKey(t => t.ShipId)
            .OnDelete(DeleteBehavior.Restrict);

        // Маршрут и рейсы: один ко многим
        modelBuilder.Entity<Trip>()
            .HasOne(t => t.Route)
            .WithMany(r => r.Trips)
            .HasForeignKey(t => t.RouteId)
            .OnDelete(DeleteBehavior.Restrict);

        // Капитан и рейсы: один ко многим
        modelBuilder.Entity<Trip>()
            .HasOne(t => t.Captain)
            .WithMany()
            .HasForeignKey(t => t.CaptainId)
            .OnDelete(DeleteBehavior.SetNull);

        // Маршрут и остановки: один ко многим
        modelBuilder.Entity<RouteStop>()
            .HasOne(rs => rs.Route)
            .WithMany(r => r.Stops)
            .HasForeignKey(rs => rs.RouteId)
            .OnDelete(DeleteBehavior.Cascade);

        // Порт и остановки маршрутов: один ко многим
        modelBuilder.Entity<RouteStop>()
            .HasOne(rs => rs.Port)
            .WithMany(p => p.RouteStops)
            .HasForeignKey(rs => rs.PortId)
            .OnDelete(DeleteBehavior.Restrict);

        // Рейс и регистрации перемещений: один ко многим
        modelBuilder.Entity<MovementRegistration>()
            .HasOne(m => m.Trip)
            .WithMany(t => t.MovementRegistrations)
            .HasForeignKey(m => m.TripId)
            .OnDelete(DeleteBehavior.Cascade);

        // Порт и регистрации перемещений: один ко многим
        modelBuilder.Entity<MovementRegistration>()
            .HasOne(m => m.Port)
            .WithMany(p => p.MovementRegistrations)
            .HasForeignKey(m => m.PortId)
            .OnDelete(DeleteBehavior.Restrict);

        // Рейс и грузовые операции: один ко многим
        modelBuilder.Entity<CargoOperation>()
            .HasOne(c => c.Trip)
            .WithMany(t => t.CargoOperations)
            .HasForeignKey(c => c.TripId)
            .OnDelete(DeleteBehavior.Cascade);

        // Рейс и пассажирские операции: один ко многим
        modelBuilder.Entity<PassengerOperation>()
            .HasOne(p => p.Trip)
            .WithMany(t => t.PassengerOperations)
            .HasForeignKey(p => p.TripId)
            .OnDelete(DeleteBehavior.Cascade);

        // Рейс и происшествия: один ко многим
        modelBuilder.Entity<Incident>()
            .HasOne(i => i.Trip)
            .WithMany(t => t.Incidents)
            .HasForeignKey(i => i.TripId)
            .OnDelete(DeleteBehavior.Cascade);

        // Точность числового значения грузоподъёмности
        modelBuilder.Entity<Ship>()
            .Property(s => s.CargoCapacity)
            .HasPrecision(18, 2);

        // Точность количества груза
        modelBuilder.Entity<CargoOperation>()
            .Property(c => c.Quantity)
            .HasPrecision(18, 2);
    }

}
