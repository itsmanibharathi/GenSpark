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
                throw new DuplicatePatientDetailsException();
            }
            item.PatientID = GenerateId();
            _patients.Add(item.PatientID, item);
            return item;
        }
        
        public Patient Get(int id)
        {
            if (_patients.Count == 0)
                throw new EmptyDataBaseException("Patient");
            return _patients[id] ?? throw new PatientIdNotFoundException();
        }
        public List<Patient> GetAll()
        {
            if (_patients.Count == 0)
                throw new EmptyDataBaseException("Patient");
            return _patients.Values.ToList();
        }

        public Patient Update(Patient item)
        {
            if (_patients.Count == 0)
                throw new EmptyDataBaseException("Patient");
            if (_patients.ContainsKey(item.PatientID))
            {
                _patients[item.PatientID] = item;
                return item;
            }
            throw new PatientIdNotFoundException();
        }

        public bool Delete(int id)
        {
            if (_patients.Count == 0)
                throw new EmptyDataBaseException("Patient");
            if (_patients.ContainsKey(id))
            {
                _patients.Remove(id);
                return true;
            }
            throw new PatientIdNotFoundException();

        }
    }
}
