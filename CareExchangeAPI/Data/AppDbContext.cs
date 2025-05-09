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
    public DbSet<JobType> JobTypes { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<Shift> Shifts { get; set; }
    public DbSet<ShiftAssignment> ShiftAssignments { get; set; }
    public DbSet<ShiftRate> ShiftRates { get; set; }
    public DbSet<Timesheet> Timesheets { get; set; }
    public DbSet<Document> Documents { get; set; }
    public DbSet<CandidateDocument> CandidateDocuments { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<CalendarEvent> CalendarEvents { get; set; }

    public DbSet<ShiftOffer> ShiftOffers { get; set; }
    public DbSet<CandidateAvailability> CandidateAvailabilities { get; set; }
    public DbSet<ShiftLog> ShiftLogs { get; set; }
    public DbSet<ShiftRating> ShiftRatings { get; set; }
    public DbSet<ShiftCancellation> ShiftCancellations { get; set; }
    public DbSet<ClientPayment> ClientPayments { get; set; }
    public DbSet<CandidatePayout> CandidatePayouts { get; set; }


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

        modelBuilder.Entity<JobType>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
        });

        modelBuilder.Entity<Shift>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Status)
                  .HasConversion<string>()
                  .IsRequired();

            entity.Property(e => e.HourlyRate)
                  .HasColumnType("decimal(10,2)");

            entity.Property(e => e.BreakMinutes)
                  .HasDefaultValue(0);

            entity.HasOne(e => e.Location)
                  .WithMany()
                  .HasForeignKey(e => e.LocationID)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.JobType)
                  .WithMany()
                  .HasForeignKey(e => e.JobTypeID)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.CreatedByClientUser)
                  .WithMany()
                  .HasForeignKey(e => e.CreatedByClientUserID)
                  .OnDelete(DeleteBehavior.Restrict);


        });
        modelBuilder.Entity<Shift>()
            .HasMany(s => s.ShiftAssignments)
            .WithOne(a => a.Shift)
            .HasForeignKey(a => a.FromShiftId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Shift>()
            .HasMany(s => s.ShiftRates)
            .WithOne(r => r.Shift)
            //.HasForeignKey(r => r.ShiftId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ShiftAssignment>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Status)
                  .HasConversion<string>()
                  .IsRequired();

            entity.HasOne(e => e.Shift)
                  .WithMany()
                  //.HasForeignKey(e => e.ShiftId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.UserProfile)
                  .WithMany()
                  .HasForeignKey(e => e.ProfileId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<ShiftRate>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.RateType)
                  .HasConversion<string>()
                  .HasDefaultValue(RateType.Base)
                  .IsRequired();

            entity.Property(e => e.HourlyRate)
                  .HasColumnType("decimal(6,2)")
                  .IsRequired();

            entity.HasOne(e => e.Shift)
                  .WithMany()
                  .HasForeignKey(e => e.Id)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        //modelBuilder.Entity<UserProfile>()
        //    .HasMany(u => u.ShiftAssignments)
        //    .WithOne(a => a.Candidate.)
        //    .HasForeignKey(a => a.CandidateID)
        //    .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Timesheet>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.SubmittedByCandidate).HasDefaultValue(false);
            entity.Property(e => e.ApprovedByClient).HasDefaultValue(false);
            entity.Property(e => e.Rejected).HasDefaultValue(false);
            entity.Property(e => e.SignedOffBy).HasMaxLength(100);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(e => e.Shift)
                  .WithMany()
                  .HasForeignKey(e => e.TimesheetShiftId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Candidate)
                  .WithMany()
                  .HasForeignKey(e => e.TimesheetUserPrifileId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Client)
                  .WithMany()
                  .HasForeignKey(e => e.TimesheetClientID)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Required).HasDefaultValue(false);
            entity.Property(e => e.ClientVisible).HasDefaultValue(false);
            entity.Property(e => e.CandidateVisible).HasDefaultValue(false);
        });

        modelBuilder.Entity<CandidateDocument>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Status)
                  .HasConversion<string>()
                  .HasDefaultValue(CandidateDocumentStatus.Uploaded);

            entity.Property(e => e.IsRequired).HasDefaultValue(true);
            entity.Property(e => e.UploadedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(e => e.Candidate)
                  .WithMany()
                  .HasForeignKey(e => e.CandidateDocID)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Document)
                  .WithMany()
                  .HasForeignKey(e => e.CanDocID)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Reviewer)
                  .WithMany()
                  .HasForeignKey(e => e.ReviewedBy)
                  .OnDelete(DeleteBehavior.SetNull);
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.RecipientType)
                  .HasConversion<string>()
                  .HasDefaultValue(RecipientType.Candidate);

            entity.Property(e => e.TypeOfNotification)
                  .HasConversion<string>()
                  .IsRequired();

            entity.Property(e => e.Title).HasMaxLength(255);
            entity.Property(e => e.IsRead).HasDefaultValue(false);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(e => e.User)
                  .WithMany()
                  .HasForeignKey(e => e.NotificationUserID)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.IsBroadcast).HasDefaultValue(false);
            entity.Property(e => e.SentAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(e => e.Sender)
                  .WithMany()
                  .HasForeignKey(e => e.SenderID)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Receiver)
                  .WithMany()
                  .HasForeignKey(e => e.ReceiverID)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<UserProfile>()
        .HasMany(u => u.SentMessages)
        .WithOne(m => m.Sender)
        .HasForeignKey(m => m.SenderID)
        .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<UserProfile>()
            .HasMany(u => u.ReceivedMessages)
            .WithOne(m => m.Receiver)
            .HasForeignKey(m => m.ReceiverID)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<CalendarEvent>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.EventType)
                  .HasConversion<string>();

            entity.HasOne(e => e.User)
                  .WithMany()
                  .HasForeignKey(e => e.CalendarUserId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Shift)
                  .WithMany()
                  .HasForeignKey(e => e.CalendarShiftId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<UserProfile>()
            .HasMany(u => u.CalendarEvents)
            .WithOne(e => e.User)
            .HasForeignKey(e => e.CalendarUserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Shift>()
            .HasMany(s => s.CalendarEvents)
            .WithOne(e => e.Shift)
            .HasForeignKey(e => e.CalendarShiftId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ShiftOffer>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.OfferStatus)
                  .HasConversion<string>()
                  .HasDefaultValue(ShiftOfferStatus.Pending);

            entity.Property(e => e.OfferedAt)
                  .HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(e => e.Shift)
                  .WithMany()
                  .HasForeignKey(e => e.ShiftOfferShiftID)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Candidate)
                  .WithMany()
                  .HasForeignKey(e => e.ShiftOfferCandidateID)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<CandidateAvailability>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Date).IsRequired();

            entity.Property(e => e.DayAvailable)
                  .HasDefaultValue(false);

            entity.Property(e => e.NightAvailable)
                  .HasDefaultValue(false);

            entity.HasOne(e => e.Candidate)
                  .WithMany(u => u.CandidateAvailabilities)
                  .HasForeignKey(e => e.CndAviCandidateID)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<ShiftLog>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.OldStatus).HasMaxLength(50);
            entity.Property(e => e.NewStatus).HasMaxLength(50);
            entity.Property(e => e.Timestamp).HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(e => e.Shift)
                  .WithMany()
                  .HasForeignKey(e => e.ShiftLogUserID)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.ChangedByUser)
                  .WithMany()
                  .HasForeignKey(e => e.ShiftLogUserID)
                  .OnDelete(DeleteBehavior.Restrict);
        });
        modelBuilder.Entity<UserProfile>()
            .HasMany(u => u.ShiftLogsChanged)
            .WithOne(log => log.ChangedByUser)
            .HasForeignKey(log => log.ShiftLogUserID)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Shift>()
            .HasMany(s => s.ShiftLogs)
            .WithOne(log => log.Shift)
            .HasForeignKey(log => log.ShiftLogId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ShiftRating>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Role)
                  .HasConversion<string>();

            entity.Property(e => e.RatingValue)
                  .IsRequired();

            entity.Property(e => e.CreatedAt)
                  .HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(e => e.Shift)
                  .WithMany(s => s.ShiftRatings)
                  .HasForeignKey(e => e.ShID)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.RatedByUser)
                  .WithMany(u => u.RatingsGiven)
                  .HasForeignKey(e => e.SRRatedByUserID)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.RatedUser)
                  .WithMany(u => u.RatingsReceived)
                  .HasForeignKey(e => e.CareRatedUserID)
                  .OnDelete(DeleteBehavior.Restrict);
        });
        modelBuilder.Entity<ShiftCancellation>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.CancelledAt)
                  .HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.Property(e => e.Approved)
                  .HasDefaultValue(false);

            entity.HasOne(e => e.Shift)
                  .WithMany()
                  .HasForeignKey(e => e.SCId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.RequestedByUser)
                  .WithMany()
                  .HasForeignKey(e => e.RequestedByUserID)
                  .OnDelete(DeleteBehavior.Restrict);


            entity.HasOne(e => e.ApprovedByUser)
                  .WithMany()
                  .HasForeignKey(e => e.ApprovedBy)
                  .OnDelete(DeleteBehavior.SetNull);
                  
        });

        modelBuilder.Entity<ClientPayment>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.InvoiceNumber).HasMaxLength(100);
            entity.Property(e => e.AmountCharged).HasColumnType("decimal(10,2)").IsRequired();
            entity.Property(e => e.PaymentDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.PaymentMethod).HasMaxLength(50);
            entity.Property(e => e.StripeTransactionID).HasMaxLength(255);

            entity.HasOne(e => e.Client)
                  .WithMany()
                  .HasForeignKey(e => e.ClienPaytId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Shift)
                  .WithMany()
                  .HasForeignKey(e => e.CPShiftId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<CandidatePayout>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.GrossAmount).HasColumnType("decimal(10,2)");
            entity.Property(e => e.PlatformFee).HasColumnType("decimal(10,2)");
            entity.Property(e => e.NetPayout).HasColumnType("decimal(10,2)");

            entity.Property(e => e.PayoutStatus)
                  .HasConversion<string>()
                  .HasDefaultValue(PayoutStatus.Pending);

            entity.Property(e => e.StripePayoutID).HasMaxLength(255);

            entity.HasOne(e => e.Candidate)
                  .WithMany()
                  .HasForeignKey(e => e.CPShiftID)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Shift)
                  .WithMany()
                  .HasForeignKey(e => e.CPShiftID)
                  .OnDelete(DeleteBehavior.Cascade);
        });
        modelBuilder.Entity<UserProfile>()
            .HasMany(u => u.CandidatePayouts)
            .WithOne(p => p.Candidate)
            .HasForeignKey(p => p.CPCandidateID)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Shift>()
            .HasMany(s => s.CandidatePayouts)
            .WithOne(p => p.Shift)
            .HasForeignKey(p => p.CPShiftID)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
