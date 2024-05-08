using System;
using System.Collections.Generic;

namespace HospitalDALLibrary.Model
{
    public partial class Appointment
    {
        public Appointment()
        {
        }
        public Appointment(Patient patient,Doctor doctor, DateTime? appointmentDate, DateTime? appointmentBookDateTime)
        {
            PatientId = patient.PatientId;
            DoctorId = doctor.DoctorId;
            AppointmentDate = appointmentDate;
            AppointmentBookDateTime = appointmentBookDateTime;
            Patient=patient;
            Doctor=doctor;
        }
        public int AppointmentId { get; set; }
        public int? PatientId { get; set; }
        public int? DoctorId { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public DateTime? AppointmentBookDateTime { get; set; }

        public virtual Doctor? Doctor { get; set; }
        public virtual Patient? Patient { get; set; }

        public override string ToString()
        {
            return $"AppointmentId: {AppointmentId}, PatientId: {PatientId}, DoctorId: {DoctorId}, AppointmentDate: {AppointmentDate}, AppointmentBookDateTime: {AppointmentBookDateTime}";
        }
    }
}
