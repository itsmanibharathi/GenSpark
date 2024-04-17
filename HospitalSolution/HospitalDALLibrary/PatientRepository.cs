using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalModuleLibrary;

namespace HospitalDALLibrary
{
    public class PatientRepository : IRepository<int, Patient>
    {
        readonly Dictionary<int, Patient> _patients = new Dictionary<int, Patient>();
        
        public PatientRepository()
        {
            _patients = new Dictionary<int, Patient>(); 
        }

        int GenerateId()
        {
            if (_patients.Count == 0)
                return 101;
            int id = _patients.Keys.Max();
            return id + 101;
        }
        /// <summary>
        ///  Add a new patient
        /// </summary>
        /// <param name="item"> Patient Details </param>
        /// <returns></returns>
        public Patient Add(Patient item)
        {
            if (_patients.ContainsValue(item))
            {
                return null;
            }
            item.PatientID = GenerateId();
            _patients.Add(item.PatientID, item);
            return item;
        }
        
        public Patient Get(int key)
        {
            return _patients[key] ?? null;
        }
        public List<Patient> GetAll()
        {
            if (_patients.Count == 0)
                return null;
            return _patients.Values.ToList();
        }

        public Patient Update(Patient item)
        {
            if (_patients.ContainsKey(item.PatientID))
            {
                _patients[item.PatientID] = item;
                return item;
            }
            return null;
        }

        public bool Delete(int key)
        {
            if (_patients.ContainsKey(key))
            {
                _patients.Remove(key);
                return true;
            }
            return false;
        }
    }
}
