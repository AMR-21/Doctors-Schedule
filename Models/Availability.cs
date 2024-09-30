using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace DoctorsSchedule.Models
{
  public class Availability
  {

    public int Id { get; set; }

    [ForeignKey("Doctor")]
    public int DocId { get; set; }

    public int DayId { get; set; }

    public TimeSpan Start { get; set; }

    public TimeSpan End { get; set; }

    [JsonIgnore]
    public virtual Doctor? Doctor { get; set; } // Made nullable

    public Day? Day { get; set; } // Made nullable
    // public ICollection<TimeSlot>? TimeSlots { get; set; }

  }
}