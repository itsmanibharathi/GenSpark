using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

using DoctorList.Module;

namespace DoctorList
{
    internal class Program
    {
        /// <summary>
        /// Get Doctor Details from user input
        /// </summary>
        /// <param name="id"> Id is requst for createing record </param>
        /// <returns> Return the created record </returns>
        Doctor getDoctoreDetials(int id)
        {
            Doctor doctor = new Doctor();
            Console.WriteLine("Enter detils for Doctor Id " + id);
            doctor.Id = id;
            Console.Write("Enter Doctor Name: ");
            doctor.Name = Console.ReadLine();
            Console.Write("Enter Doctor Age: ");
            int age;
            while (!int.TryParse(Console.ReadLine(), out age))
            {
                Console.WriteLine("Invalid Input, Please enter a valid number");
                Console.Write("Enter Doctor Age:");
            }
            doctor.Id = age;
            Console.Write("Enter Doctor Experience: ");
            int exp;
            while (!int.TryParse(Console.ReadLine(), out exp))
            {
                Console.WriteLine("Invalid Input, Please enter a valid number");
                Console.Write("Enter Doctor Experience:");
            }
            doctor.Exp = exp;
            Console.Write("Enter Doctor Qualification: ");
            doctor.Qualification = Console.ReadLine();
            Console.Write("Enter Doctor Speciality: ");
            doctor.Speciality = Console.ReadLine();
            return doctor;
        }
        static void Main(string[] args)
        {
            const string line = "-------------------------------------------------";
            Program program = new Program();

            Console.Write("Enter Number of Doctors: ");
            int doctorCount;
            while (!int.TryParse(Console.ReadLine(), out doctorCount))
            {
                Console.WriteLine("Invalid Input, Please enter a valid number");
                Console.Write("Enter Number of Doctors: ");
            }
            Doctor[] doctor = new Doctor[doctorCount];
            for (int i = 0; i < doctor.Length; i++)
            {
                doctor[i] = program.getDoctoreDetials(i);
            }
            Console.WriteLine(line);
            for (int i = 0; i < doctor.Length; i++)
            {
                new Doctor().DisplayDoctor(doctor[i]);
            }
            Console.WriteLine(line);
            Console.Write("Enter Speciality to find Doctor: ");
            string speciality = Console.ReadLine();
            new Doctor().FindDoctor(doctor, speciality);
        }
    }
}
