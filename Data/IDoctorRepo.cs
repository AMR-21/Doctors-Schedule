using DoctorsSchedule.Models;
using DoctorsSchedule.DTOs;

namespace DoctorsSchedule.Data
{
  public interface IDoctorRepo
  {
    Task<IEnumerable<Doctor>> GetDoctorsAsync();
    Task<Doctor?> GetDoctorAsync(int id);
    Task<DoctorDTO?> GetDoctorDetailsAsync(int id);
    Task UpdateDoctorAsync(Doctor doctor);
    Task AddDoctorAsync(Doctor doctor);
    Task UpdateDoctorAvailabilityAsync(int id, int availabilityId, AvailabilityDTO availabilityDTO);
    Task AddDoctorAvailabilityAsync(int id, AvailabilityDTO availabilityDTO);
    bool DoctorExists(int id);
  }
}