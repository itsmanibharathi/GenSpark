using ClinicAPI.Exceptions;
using ClinicAPI.Interfaces;
using ClinicAPI.Models;
using ClinicAPI.Repositores;

namespace ClinicAPI.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IRepository<int,Doctor> _repository;

        public DoctorService(IRepository<int, Doctor> doctorRepository)
        {
            _repository = doctorRepository;
        }

        public async Task<IEnumerable<Doctor>> Get()
        {
            return await _repository.Get();
        }

        public async Task<Doctor> Get(int id)
        {
            return await _repository.Get(id);
        }

        public async Task<IEnumerable<Doctor>> GetBySpecialization(string specialization)
        {
            var res = (await _repository.Get()).Where(d => d.Specialization == specialization);
            if (res.Any())
            {
                return res;
            }
            throw new NoDoctorFoundInThisSpecializationException(specialization);
        }

    }
}
