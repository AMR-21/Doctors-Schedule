using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore; // Add this using directive

namespace DoctorsSchedule.Models
{
  public class Day
  {
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public ICollection<Availability>? Availabilities { get; set; }

  }
}
