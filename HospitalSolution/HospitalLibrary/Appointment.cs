using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalModuleLibrary
{
    /// <summary>
    /// Represents an appointment in the hospital
    /// </summary>
    public class Appointment 
    {
        public int AppointmentID { get; set; }
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
        DateTime _AppointmentDate = DateTime.MinValue;
        DateTime AppointmentBookDateTime = DateTime.MinValue;

        public DateTime AppointmentDate { 
            get { 
                return _AppointmentDate; 
            }
            set
            {
                if (value < DateTime.Now)
                {
                    throw new Exception("Appointment date cannot be in the past");
                }
                
                _AppointmentDate = value;
                AppointmentBookDateTime = DateTime.Now;
            }
        }
        public string AppointmentTime { get; set; }

        /// <summary>
        /// Appointment default constructor
        /// </summary>
        public Appointment()
        {
            AppointmentID = 0;
        }

        /// <summary>
        /// Appointment constructor with parameters
        /// </summary>
        /// <param name="patientID"> PatientID</param>
        /// <param name="doctorID"> DoctorID </param>
        /// <param name="appointmentDate"> To with Data Create Appointment </param>
        /// <param name="appointmentTime"> Appointment Time </param>
        public Appointment(int patientID, int doctorID, DateTime appointmentDate, string appointmentTime)
        {
            PatientID = patientID;
            DoctorID = doctorID;
            AppointmentDate = appointmentDate;
            AppointmentTime = appointmentTime;
        }
        public override string ToString()
        {
            return $"Appointment ID: {AppointmentID},\n Patient ID: {PatientID},\n Doctor ID: {DoctorID},\n Appointment Date: {AppointmentDate},\n Appointment Time: {AppointmentTime}, \n AppointmentBook Time Stamp {AppointmentBookDateTime}";
        }
    }
}
