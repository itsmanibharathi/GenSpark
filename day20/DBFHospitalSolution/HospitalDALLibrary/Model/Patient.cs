using System;
using System.Collections.Generic;

namespace HospitalDALLibrary.Model
{
    public partial class Patient
    {
        public Patient()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int PatientId { get; set; }
        public string? PatientName { get; set; }
        public int? PatientAge { get; set; }
        public string? PatientGender { get; set; }
        public string? PatientAddress { get; set; }
        public string? PatientPhoneNumber { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
