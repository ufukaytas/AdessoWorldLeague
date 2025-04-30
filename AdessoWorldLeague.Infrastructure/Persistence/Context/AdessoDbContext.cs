using AdessoWorldLeague.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdessoWorldLeague.Infrastructure.Persistence.Context;

public class AdessoDbContext : DbContext
{
    public AdessoDbContext(DbContextOptions<AdessoDbContext> options) : base(options) { }

    public DbSet<Country> Countries => Set<Country>();
    public DbSet<Team> Teams => Set<Team>();
    public DbSet<Group> Groups => Set<Group>();
    public DbSet<Draw> Draws => Set<Draw>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // COUNTRY
        modelBuilder.Entity<Country>(entity =>
        {
            entity.ToTable("Countries");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Name).IsRequired().HasMaxLength(50);
        });

        // TEAM
        modelBuilder.Entity<Team>(entity =>
        {
            entity.ToTable("Teams");
            entity.HasKey(t => t.Id);
            entity.Property(t => t.Name).IsRequired().HasMaxLength(100);
            entity.HasOne(t => t.Country)
                  .WithMany(c => c.Teams)
                  .HasForeignKey(t => t.CountryId);
        });

        // DRAW
        modelBuilder.Entity<Draw>(entity =>
        {
            entity.ToTable("Draws");
            entity.HasKey(d => d.Id);
            entity.Property(d => d.DrawnBy).IsRequired().HasMaxLength(100);
            entity.Property(d => d.Date).IsRequired();
        });

        // GROUP
        modelBuilder.Entity<Group>(entity =>
        {
            entity.ToTable("Groups");
            entity.HasKey(g => g.Id);
            entity.Property(g => g.GroupName).IsRequired().HasMaxLength(5);

            entity.HasOne(g => g.Draw)
                  .WithMany(d => d.Groups)
                  .HasForeignKey(g => g.DrawId);

            // Group -> Team ilişkisinde Team'leri burada ayrı bir tablo ile ilişkilendiriyoruz (Many-to-Many istenirse ekstra tablo kurulur)
            entity.HasMany(g => g.Teams);
        });
    }
}