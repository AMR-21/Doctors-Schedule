using DoctorsSchedule.Models;
using Microsoft.EntityFrameworkCore;

namespace DoctorsSchedule.Data;

public class DoctorsScheduleContext : DbContext
{
  public DoctorsScheduleContext(DbContextOptions<DoctorsScheduleContext> options)
      : base(options)
  {
  }

  public DbSet<Doctor> Doctors { get; set; }
  public DbSet<Availability> Availabilities { get; set; }
  public DbSet<Day> Days { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    // Define the one-to-many relationship
    modelBuilder.Entity<Availability>()
        .HasOne(s => s.Doctor)
        .WithMany(d => d.Availabilities)
        .HasForeignKey(s => s.DocId)
        .OnDelete(DeleteBehavior.Cascade);

    // modelBuilder.Entity<TimeSlot>().HasOne(t => t.Availability).WithMany(s => s!.TimeSlots).HasForeignKey(t => t.AvailabilityId).OnDelete(DeleteBehavior.Cascade);

    modelBuilder.Entity<Day>()
        .HasMany(d => d.Availabilities)
        .WithOne(a => a.Day)
        .HasForeignKey(a => a.DayId)
        .OnDelete(DeleteBehavior.Cascade);


    modelBuilder.Entity<Doctor>(

    ).HasData(
      new Doctor { Id = 1, Name = "Mohamed" },
      new Doctor { Id = 2, Name = "Ahmed" }
    );

    modelBuilder.Entity<Day>(

    ).HasData(
      new Day { Id = 1, Name = "Sunday" },
      new Day { Id = 2, Name = "Monday" },
      new Day { Id = 3, Name = "Tuesday" },
      new Day { Id = 4, Name = "Wednesday" },
      new Day { Id = 5, Name = "Thursday" },
      new Day { Id = 6, Name = "Friday" },
      new Day { Id = 7, Name = "Saturday" }
    );

    modelBuilder.Entity<Availability>(
    ).HasData(
        new Availability { Id = 1, DocId = 1, DayId = 2, Start = new TimeSpan(9, 0, 0), End = new TimeSpan(13, 0, 0) },
        new Availability { Id = 2, DocId = 1, DayId = 2, Start = new TimeSpan(2, 0, 0), End = new TimeSpan(18, 0, 0) },
        new Availability { Id = 3, DocId = 1, DayId = 3, Start = new TimeSpan(9, 0, 0), End = new TimeSpan(13, 0, 0) },
        new Availability { Id = 4, DocId = 1, DayId = 3, Start = new TimeSpan(2, 0, 0), End = new TimeSpan(18, 0, 0) },
        new Availability { Id = 5, DocId = 1, DayId = 3, Start = new TimeSpan(20, 0, 0), End = new TimeSpan(21, 0, 0) },
        new Availability { Id = 6, DocId = 1, DayId = 4, Start = new TimeSpan(9, 0, 0), End = new TimeSpan(13, 0, 0) },
        new Availability { Id = 7, DocId = 1, DayId = 4, Start = new TimeSpan(2, 0, 0), End = new TimeSpan(18, 0, 0) },
        new Availability { Id = 8, DocId = 1, DayId = 5, Start = new TimeSpan(2, 0, 0), End = new TimeSpan(18, 0, 0) },
        new Availability { Id = 9, DocId = 1, DayId = 6, Start = new TimeSpan(9, 0, 0), End = new TimeSpan(18, 0, 0) },
        new Availability { Id = 10, DocId = 2, DayId = 2, Start = new TimeSpan(9, 0, 0), End = new TimeSpan(17, 0, 0) },
        new Availability { Id = 11, DocId = 2, DayId = 3, Start = new TimeSpan(9, 0, 0), End = new TimeSpan(13, 0, 0) },
        new Availability { Id = 12, DocId = 2, DayId = 3, Start = new TimeSpan(8, 0, 0), End = new TimeSpan(21, 0, 0) },
        new Availability { Id = 13, DocId = 2, DayId = 5, Start = new TimeSpan(2, 0, 0), End = new TimeSpan(18, 0, 0) },
        new Availability { Id = 14, DocId = 2, DayId = 6, Start = new TimeSpan(9, 0, 0), End = new TimeSpan(13, 0, 0) }
    );
  }
}