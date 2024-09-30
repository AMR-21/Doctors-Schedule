using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace DoctorsSchedule.Models;

public class Doctor
{
  public int Id { get; set; }

  [Required]
  public string Name { get; set; } = string.Empty;


  [JsonIgnore]
  public ICollection<Availability>? Availabilities { get; set; }
}