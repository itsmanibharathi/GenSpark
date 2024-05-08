using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace HospitalModuleLibrary
{
    /// <summary>
    /// Doctor class
    /// </summary>
    public class Doctor
    {
        public int DoctorID { get; set; }
        string DoctorName { get; set; }
        string DoctorSpecialization { get; set; }
        /// <summary>
        /// Doctor default constructor
        /// </summary>
        public Doctor()
        {
            DoctorID = 0;
        }
        /// <summary>
        /// Doctor constructor with parameters
        /// </summary>
        /// <param name="doctorName"> DoctorName </param>
        /// <param name="doctorSpecialization"> Doctor Specialization </param>
        public Doctor(string doctorName, string doctorSpecialization)
        {   
            DoctorName = doctorName;
            DoctorSpecialization = doctorSpecialization;
        }
        public override string ToString()
        {
            return $" Doctor ID: {DoctorID},\n Doctor Name: {DoctorName},\n Doctor Specialization: {DoctorSpecialization}";
        }

        public static string GetDoctorNameFromConsole()
        {
            Console.Write("Enter Doctor Name: ");
            while (true)
            {
                string name = Console.ReadLine();
                if (!string.IsNullOrEmpty(name))
                {
                    return name;
                }
                Console.Write("Doctor Name cannot be empty.\nPlease enter a valid name: ");
            }
        }

        public static string GetDoctorSpecializationFromConsole()
        {
            Console.Write("Enter Doctor Specialization: ");
            while (true)
            {
                string specialization = Console.ReadLine();
                if (!string.IsNullOrEmpty(specialization))
                {
                    return specialization;
                }
                Console.Write("Doctor Specialization cannot be empty.\nPlease enter a valid specialization: ");
            }
        }
        public void GetDoctorDetailsFromConsole()
        {
            DoctorName = GetDoctorNameFromConsole();
            DoctorSpecialization = GetDoctorSpecializationFromConsole();
        }

    }
}
