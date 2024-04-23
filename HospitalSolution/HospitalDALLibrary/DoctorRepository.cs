using HospitalModuleLibrary;
using System.Diagnostics.CodeAnalysis;
namespace HospitalDALLibrary
{
    /// <summary>
    ///  Doctor Repository
    /// </summary>
    public class DoctorRepository : IRepository<int, Doctor>
    {
        readonly Dictionary<int, Doctor> _doctors;
        public DoctorRepository()
        {
            _doctors = new Dictionary<int, Doctor>();
        }
        [ExcludeFromCodeCoverage]
        int GenerateId()
        {
            if (_doctors.Count == 0)
                return 1;
            int id = _doctors.Keys.Max();
            return ++id;
        }
        /// <summary>
        /// Add a new doctor
        /// </summary>
        /// <param name="item"> Doctor Details </param>
        /// <returns></returns>
        public Doctor Add(Doctor item)
        {
            if (_doctors.ContainsValue(item))
            {
                throw new DuplicateDoctorDetailsException();
            }
            item.DoctorID = GenerateId();
            _doctors.Add(item.DoctorID, item);
            return item;
            
        }

        /// <summary>
        /// Get the doctor by ID
        /// </summary>
        /// <param name="key"> Docter Id </param>
        /// <returns>return Docter details</returns>
        public Doctor Get(int id)
        {
            if (_doctors.Count == 0)
                throw new EmptyDataBaseException("Doctor");
            return _doctors[id] ?? throw new DoctorIdNotFoundException(id); 
        }
        /// <summary>
        /// Get all the doctors
        /// </summary>
        /// <returns> Docters details return in list </returns>

        public System.Collections.Generic.List<Doctor> GetAll()
        {
            if (_doctors.Count == 0)
                throw new EmptyDataBaseException("Doctor");
            return _doctors.Values.ToList();
        }

        /// <summary>
        /// Update the doctor details
        /// </summary>
        /// <param name="item">new Details</param>
        /// <returns> return update details </returns>
        public Doctor Update(Doctor item)
        {
            if (_doctors.ContainsValue(item))
            {
                throw new DuplicateDoctorDetailsException();
            }
            foreach (var doctor in _doctors)
            {
                if (doctor.Value.DoctorID == item.DoctorID)
                {
                    _doctors[doctor.Key] = item;
                    return item;
                }
            }
            throw new DoctorIdNotFoundException(item.DoctorID);
        }
        /// <summary>
        /// Delete the doctor details by ID
        /// </summary>
        /// <param name="key"> ID </param>
        /// <returns>return deleted Status</returns>
        public bool Delete(int id)
        {
            if (_doctors.Count == 0)
                throw new EmptyDataBaseException("Doctor");
            if (_doctors.ContainsKey(id))
            {
                _doctors.Remove(id);
                return true;
            }
            throw new DoctorIdNotFoundException(id);
        }
    }
}
