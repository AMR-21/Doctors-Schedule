using DoctorsSchedule.Models;
using DoctorsSchedule.DTOs;
using Microsoft.EntityFrameworkCore;





namespace DoctorsSchedule.Data
{
  public class DoctorRepo : IDoctorRepo
  {
    private readonly DoctorsScheduleContext _context;

    public DoctorRepo(DoctorsScheduleContext context)
    {
      _context = context;
    }

    public async Task<IEnumerable<Doctor>> GetDoctorsAsync()
    {
      return await _context.Doctors.ToListAsync();
    }

    public async Task<Doctor?> GetDoctorAsync(int id)
    {
      return await _context.Doctors.FindAsync(id);
    }

    public async Task<DoctorDTO?> GetDoctorDetailsAsync(int id)
    {
      var doctor = await _context.Doctors
          .Include(d => d.Availabilities!)
              .ThenInclude(a => a.Day!)
          .FirstOrDefaultAsync(d => d.Id == id);

      if (doctor == null)
      {
        return null;
      }

      return new DoctorDTO
      {
        doctorId = doctor.Id,
        Name = doctor.Name,
        Availabilities = doctor.Availabilities?.Select(a => new AvailabilityDTO
        {
          id = a.Id,
          day = a.Day!.Name,
          Start = GetTime(a.Start),
          End = GetTime(a.End),
        }).ToList() ?? new List<AvailabilityDTO>()
      };
    }

    public async Task UpdateDoctorAsync(Doctor doctor)
    {
      _context.Entry(doctor).State = EntityState.Modified;
      await _context.SaveChangesAsync();
    }

    public async Task AddDoctorAsync(Doctor doctor)
    {
      _context.Doctors.Add(doctor);
      await _context.SaveChangesAsync();
    }

    public async Task UpdateDoctorAvailabilityAsync(int id, int availabilityId, AvailabilityDTO availabilityDTO)
    {
      var doctor = await _context.Doctors.Include(d => d.Availabilities).FirstOrDefaultAsync(d => d.Id == id);
      if (doctor == null)
      {
        return;
      }

      var existingAvailability = doctor.Availabilities?.FirstOrDefault(a => a.Id == availabilityDTO.id && a.Id == availabilityId);
      if (existingAvailability == null)
      {
        return;
      }

      existingAvailability.DayId = DaysMap.Days.FirstOrDefault(d => d.Value == availabilityDTO.day).Key;

      if (!string.IsNullOrEmpty(availabilityDTO.Start))
      {
        existingAvailability.Start = TimeSpan.Parse(availabilityDTO.Start);
      }
      if (!string.IsNullOrEmpty(availabilityDTO.End))
      {
        existingAvailability.End = TimeSpan.Parse(availabilityDTO.End);
      }

      _context.Entry(existingAvailability).State = EntityState.Modified;
      await _context.SaveChangesAsync();
    }

    public async Task AddDoctorAvailabilityAsync(int id, AvailabilityDTO availabilityDTO)
    {
      var doctor = await _context.Doctors.Include(d => d.Availabilities).FirstOrDefaultAsync(d => d.Id == id);
      if (doctor == null)
      {
        return;
      }

      var availability = new Availability
      {
        DayId = DaysMap.Days.FirstOrDefault(d => d.Value == availabilityDTO.day).Key,
        Start = TimeSpan.Parse(availabilityDTO.Start!),
        End = TimeSpan.Parse(availabilityDTO.End!)
      };

      doctor.Availabilities?.Add(availability);
      _context.Entry(doctor).State = EntityState.Modified;
      await _context.SaveChangesAsync();
    }

    public bool DoctorExists(int id)
    {
      return _context.Doctors.Any(e => e.Id == id);
    }

    private string GetTime(TimeSpan time)
    {
      return time.Hours > 12 ? time.Subtract(new TimeSpan(12, 0, 0)).ToString(@"hh\:mm") + " PM" : time.Hours == 12 ? time.ToString(@"hh\:mm") + " PM" : time.ToString(@"hh\:mm") + " AM";
    }
  }
}