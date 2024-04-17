﻿using System;
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
                return null;
            }
            item.AppointmentID = GenerateId();
            _Appointments.Add(item.AppointmentID, item);
            return item;
        }

        public List<Appointment> GetAll()
        {
            if (_Appointments.Count == 0)
                return null;
            return _Appointments.Values.ToList();
        }

        public Appointment Get(int key)
        {
            return _Appointments[key] ?? null;
        }

        public Appointment Update(Appointment item)
        {
            if (_Appointments.ContainsKey(item.AppointmentID))
            {
                _Appointments[item.AppointmentID] = item;
                return item;
            }
            return null;
        }

        public bool Delete(int key)
        {
            if (_Appointments.ContainsKey(key))
            {
                _Appointments.Remove(key);
                return true;
            }
            return false;
        }
    }
}
