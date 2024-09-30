namespace DoctorsSchedule.DTOs
{
  public class DayDTO
  {
    public int dayId { get; set; }
    public string Name { get; set; } = string.Empty;
  }

  public class AvailabilityDTO
  {
    public int id { get; set; } // This should match the availability ID
    public string? day { get; set; } // The day of the week
    public string? Start { get; set; } // Start time
    public string? End { get; set; } // End time (optional, if you want to allow updates to end time)
  }

  public class DoctorDTO
  {
    public int doctorId { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<AvailabilityDTO> Availabilities { get; set; } = new List<AvailabilityDTO>();
  }
}