using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DoctorList.Module
{
    /// <summary>
    /// Doctor class to store doctor details
    /// </summary>
    internal class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Exp { get; set; }
        public string Qualification { get; set; }
        public string Speciality { get; set; }

        /// <summary>
        /// Display Doctor Details
        /// </summary>
        /// <param name="doctor">Class obj is requst</param>
        public void DisplayDoctor(Doctor doctor)
        {
            Console.WriteLine("Doctor Id: " + doctor.Id);
            Console.WriteLine("Doctor Name: " + doctor.Name);
            Console.WriteLine("Doctor Age: " + doctor.Age);
            Console.WriteLine("Doctor Experience: " + doctor.Exp);
            Console.WriteLine("Doctor Qualification: " + doctor.Qualification);
            Console.WriteLine("Doctor Speciality: " + doctor.Speciality);
        }
        /// <summary>
        /// Find Doctor by Speciality
        /// </summary>
        /// <param name="doctor"> Requst the doctor array </param>
        /// <param name="speciality"> Requst Find by  speciality  </param>
        public void FindDoctor(Doctor[] doctor, string speciality)
        {
            for (int i = 0; i < doctor.Length; i++)
            {
                if (doctor[i].Speciality == speciality)
                {
                    DisplayDoctor(doctor[i]);
                }
            }
        }
    }

}
