using HospitalDALLibrary;
using HospitalDALLibrary.Model;
namespace HospitalApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            // Create a new Doctor object
            //Doctor doctor = new Doctor(1, "John Doe", "General Physician");
            //Console.WriteLine(doctor);

            //Create a new DoctorRepository object
            //DoctorRepository doctorRepository = new DoctorRepository();
            //// Add the doctor object to the repository
            //doctorRepository.Add(new Doctor("John Doe", "General Physician"));

            //doctorRepository.GetAll().ForEach(Console.WriteLine);

            DoctorRepository doctorRepository = new DoctorRepository();
            //Doctor doctor = new Doctor("John Doe", "General Physician");    
            //doctorRepository.Add(doctor);
            var doctors = doctorRepository.GetAll();
            doctors.ForEach(Console.WriteLine);

        }
    }
}
