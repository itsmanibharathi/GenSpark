using ClinicAPI.Models;

namespace ClinicAPI.Interfaces
{
    public interface IDoctorService
    {
        public Task<IEnumerable<Doctor>> Get();
        public Task<Doctor> Get(int id);
        public Task<IEnumerable<Doctor>> GetBySpecialization(string specialization);


    }
}
