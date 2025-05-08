using CareExchangeAPI.Models;
using CareExchangeAPI.Models.Enums;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace CareExchangeAPI.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<User>(options)
{

    public DbSet<UserProfile> UserProfiles { get; set; } = null!;
    public DbSet<CareHomeClient> CareHomeClients { get; set; } = null!;
    public DbSet<CareHomeClientLocation> CareHomeClientLocations { get; set; } = null!;



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<UserProfile>(entity =>
        {
            entity.ToTable("UserProfiles");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.ProfileUserID)
                  .IsRequired();

            entity.HasIndex(e => e.ProfileUserID)
                  .IsUnique(); // Assuming one-to-one relationship

            entity.HasOne(e => e.User)
                  .WithOne()
                  .HasForeignKey<UserProfile>(e => e.ProfileUserID)
                  .HasPrincipalKey<User>(u => u.Id) // Assuming User.Id is string
                  .OnDelete(DeleteBehavior.Cascade);

            entity.Property(e => e.FirstName).IsRequired();
            entity.Property(e => e.LastName).IsRequired();
            entity.Property(e => e.PreferredName).HasDefaultValue(string.Empty);
            entity.Property(e => e.Email).IsRequired();
            entity.Property(e => e.Mobile).IsRequired();
            entity.Property(e => e.PhoneVisibleToClients).HasDefaultValue(false);
            entity.Property(e => e.ProfilePhoto);
            entity.Property(e => e.LastLogin);

            entity.Property(e => e.Status)
                  .HasConversion<string>()
                  .HasDefaultValue(UserStatus.Active);

            entity.Property(e => e.HomeAddress);
            entity.Property(e => e.HomeCity);
            entity.Property(e => e.HomePostCode);
            entity.Property(e => e.WorkingAddress);
            entity.Property(e => e.WorkingCity);
            entity.Property(e => e.WorkingPostCode);

            entity.Property(e => e.EmploymentType)
                  .HasConversion<string>();

            entity.Property(e => e.DateOfBirth);
            entity.Property(e => e.StartedAtCX);

            entity.Property(e => e.PayrollID)
                  .HasMaxLength(50);
        });
        modelBuilder.Entity<CareHomeClient>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Name).IsRequired().HasMaxLength(255);
            entity.Property(e => e.LegalEntity).HasMaxLength(255);
            entity.Property(e => e.CompanyNumber).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.Property(e => e.CareHomeClientUserID).IsRequired();

            entity.HasOne(e => e.User)
                  .WithMany()
                  .HasForeignKey(e => e.CareHomeClientUserID)
                  .OnDelete(DeleteBehavior.Cascade);
        });

    }
}
