using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using APPR_P_2.Models;

namespace APPR_P_2.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Donation> Donations { get; set; }
        public DbSet<VolunteerProfile> VolunteerProfiles { get; set; }
        public DbSet<IncidentReport> IncidentReports { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configure relationships
            builder.Entity<Donation>()
                .HasOne(d => d.Donor)
                .WithMany(u => u.Donations)
                .HasForeignKey(d => d.DonorId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<VolunteerProfile>()
                .HasOne(v => v.User)
                .WithOne(u => u.VolunteerProfile)
                .HasForeignKey<VolunteerProfile>(v => v.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<IncidentReport>()
                .HasOne(i => i.User)
                .WithMany(u => u.IncidentReports)
                .HasForeignKey(i => i.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure collections to be stored as JSON in InMemory database
            builder.Entity<Donation>()
                .Property(d => d.Supplies)
                .HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
                );

            builder.Entity<VolunteerProfile>()
                .Property(v => v.Skills)
                .HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
                );
        }
    }
}