// Controllers/DoctorsController.cs
using Microsoft.AspNetCore.Mvc;
using DoctorsSchedule.Models;
using DoctorsSchedule.DTOs;
using DoctorsSchedule.Data;
using Microsoft.EntityFrameworkCore;




namespace DoctorsSchedule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorRepo _doctorRepo;

        public DoctorsController(IDoctorRepo doctorRepo)
        {
            _doctorRepo = doctorRepo;
        }

        // GET: api/Doctors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetDoctors()
        {
            return Ok(await _doctorRepo.GetDoctorsAsync());
        }

        // GET: api/Doctors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Doctor>> GetDoctor(int id)
        {
            var doctor = await _doctorRepo.GetDoctorAsync(id);

            if (doctor == null)
            {
                return NotFound();
            }

            return doctor;
        }

        // GET: api/Doctors/5/Details
        [HttpGet("{id}/availabilities")]
        public async Task<ActionResult<DoctorDTO>> GetDoctorDetails(int id)
        {
            var doctorDTO = await _doctorRepo.GetDoctorDetailsAsync(id);

            if (doctorDTO == null)
            {
                return NotFound();
            }

            return doctorDTO;
        }

        // PUT: api/Doctors/5
        // [HttpPut("{id}")]
        // public async Task<IActionResult> PutDoctor(int id, Doctor doctor)
        // {
        //     if (id != doctor.Id)
        //     {
        //         return BadRequest();
        //     }

        //     try
        //     {
        //         await _doctorRepo.UpdateDoctorAsync(doctor);
        //     }
        //     catch (DbUpdateConcurrencyException)
        //     {
        //         if (!_doctorRepo.DoctorExists(id))
        //         {
        //             return NotFound();
        //         }
        //         else
        //         {
        //             throw;
        //         }
        //     }

        //     return NoContent();
        // }

        // POST: api/Doctors
        [HttpPost]
        public async Task<ActionResult<Doctor>> PostDoctor(Doctor doctor)
        {
            await _doctorRepo.AddDoctorAsync(doctor);
            return CreatedAtAction("GetDoctor", new { id = doctor.Id }, doctor);
        }

        // PUT: api/Doctors/5/Availability
        [HttpPut("{id}/availabilities/{availabilityId}")]
        public async Task<IActionResult> UpdateDoctorAvailability(int id, int availabilityId, AvailabilityDTO availabilityDTO)
        {
            // Validate the day
            if (!IsValidDay(availabilityDTO.day!))
            {
                return BadRequest("Invalid day provided.");
            }

            try
            {
                await _doctorRepo.UpdateDoctorAvailabilityAsync(id, availabilityId, availabilityDTO);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_doctorRepo.DoctorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        // PUT: api/Doctors/5/Availabilities
        [HttpPost("{id}/availabilities")]
        public async Task<IActionResult> UpdateDoctorAvailabilities(int id, List<AvailabilityDTO> availabilityDTOs)
        {

            // Validate each day in the list
            foreach (var availabilityDTO in availabilityDTOs)
            {
                if (!IsValidDay(availabilityDTO.day!))
                {
                    return BadRequest("Invalid day provided.");
                }
            }



            // Remove old availabilities
            await _doctorRepo.DeleteAvailabilitiesAsync(id);

            // Add new availabilities
            foreach (var availabilityDTO in availabilityDTOs)
            {
                await _doctorRepo.AddDoctorAvailabilityAsync(id, availabilityDTO);
            }

            return CreatedAtAction("GetDoctor", new { id }, availabilityDTOs);
        }

        // Helper method to validate the day
        private bool IsValidDay(string day)
        {
            var validDays = new List<string> { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            return validDays.Contains(day);
        }
    }
}