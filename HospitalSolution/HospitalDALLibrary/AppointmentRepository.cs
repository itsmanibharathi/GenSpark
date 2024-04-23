using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalModuleLibrary;

namespace HospitalDALLibrary
{
    internal class AppointmentRepository : IRepository<int, Appointment>
    {
        readonly Dictionary<int, Appointment> _Appointments = new Dictionary<int, Appointment>();

        public AppointmentRepository()
        {
            _Appointments = new Dictionary<int, Appointment>();
        }

        int GenerateId()
        {
            if (_Appointments.Count == 0)
                return 1001;
            int id = _Appointments.Keys.Max();
            return id + 1001;
        }

        public Appointment Add(Appointment item)
        {
            if (_Appointments.ContainsValue(item))
            {
                throw new DuplicateAppointmentDetailsException();
            }
            item.AppointmentID = GenerateId();
            _Appointments.Add(item.AppointmentID, item);
            return item;
        }

        public List<Appointment> GetAll()
        {
            if (_Appointments.Count == 0)
                throw new EmptyDataBaseException("Appointment");
            return _Appointments.Values.ToList();
        }

        public Appointment Get(int key)
        {
            if (_Appointments.Count == 0)
                throw new EmptyDataBaseException("Appointment");
            return _Appointments[key] ?? throw new AppointmentIdNotFoundException();
        }

        public Appointment Update(Appointment item)
        {
            if (_Appointments.Count == 0)
                throw new EmptyDataBaseException("Appointment");
            if (_Appointments.ContainsKey(item.AppointmentID))
            {
                _Appointments[item.AppointmentID] = item;
                return item;
            }
            throw new AppointmentIdNotFoundException(item.AppointmentID);
        }

        public bool Delete(int key)
        {
            if (_Appointments.Count == 0)
                throw new EmptyDataBaseException("Appointment");
            if (_Appointments.ContainsKey(key))
            {
                _Appointments.Remove(key);
                return true;
            }
            throw new AppointmentIdNotFoundException(key);
        }
    }
}
