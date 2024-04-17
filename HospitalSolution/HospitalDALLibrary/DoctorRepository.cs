using HospitalModuleLibrary;
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
                return null;
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
        public Doctor Get(int key)
        {
            return _doctors[key]??null;
        }
        /// <summary>
        /// Get all the doctors
        /// </summary>
        /// <returns> Docters details return in list </returns>

        public System.Collections.Generic.List<Doctor> GetAll()
        {
            if (_doctors.Count == 0)
                return null;
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
                return null;
            }
            foreach (var doctor in _doctors)
            {
                if (doctor.Value.DoctorID == item.DoctorID)
                {
                    _doctors[doctor.Key] = item;
                    return item;
                }
            }
            return null;
        }
        /// <summary>
        /// Delete the doctor details by ID
        /// </summary>
        /// <param name="key"> ID </param>
        /// <returns>return deleted Status</returns>
        public bool Delete(int key)
        {
            if (_doctors.ContainsKey(key))
            {
                _doctors.Remove(key);
                return true;
            }
            return false;
        }


    }
}
