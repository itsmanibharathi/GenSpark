using ClinicAPI.Contexts;
using ClinicAPI.Exceptions;
using ClinicAPI.Interfaces;
using ClinicAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicAPI.Repositores
{
    public class DoctorRepository : IRepository<int, Doctor>
    {
        private readonly DBClinicContext _context;

        public DoctorRepository(DBClinicContext dBClinicContext)
        {
            _context = dBClinicContext;
        }

        public async Task<Doctor> Add(Doctor entity)
        { 
            _context.Doctors.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<Doctor> Get(int key)
        {
            var res = await _context.Doctors.FindAsync(key);
            if (res != null)
            {
                return res;
            }
            throw new NoDoctorFoundException(key);
        }

        public async Task<IEnumerable<Doctor>> Get()
        {
            var res = await _context.Doctors.ToListAsync();
            if (res.Count() ==0)
                throw new EmptyDataBaseException("Doctors");
            return res;
        }
        public async Task<Doctor> Update(Doctor entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return await Get(entity.ID);
        }
        public async Task<bool> Delete(int key)
        {
            var doctor = await Get(key);
            _context.Doctors.Remove(doctor);
            var res = await _context.SaveChangesAsync();
            return res > 0;
        }
    }
}
