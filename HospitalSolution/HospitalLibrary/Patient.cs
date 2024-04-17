using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalModuleLibrary
{
    public class Patient
    {
        public int PatientID { get; set; }
        public string PatientName { get; set; }
        public int PatientAge { get; set; }
        public string PatientGender { get; set; }
        public string PatientAddress { get; set; }
        public string PatientPhoneNumber { get; set; }

        public Patient()
        {
            PatientID = 0;
        }

        public Patient(string patientName, string patientGender, int patientAge, string patientAddress, string patientPhoneNumber)
        {
            PatientName = patientName;
            PatientGender = patientGender;
            PatientAge = patientAge;
            PatientAddress = patientAddress;
            PatientPhoneNumber = patientPhoneNumber;
        }

        public override string ToString()
        {
            return $" Patient ID: {PatientID},\n Patient Name: {PatientName},\n Patient Age: {PatientAge},\n Patient Gender: {PatientGender},\n Patient Address: {PatientAddress},\n Patient Phone Number: {PatientPhoneNumber}";
        }

    }
}
