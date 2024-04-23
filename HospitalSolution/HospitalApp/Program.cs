using HospitalModuleLibrary;
using HospitalDALLibrary;
using HospitalBLLibrary;
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


            // patient
            Patient patient = new Patient("Mani", "Male", 22, "Erode", "123456");
            Console.WriteLine(patient);
            PatientRepository patientRepository = new PatientRepository();
            Console.WriteLine(patientRepository.Add(patient));

        }
    }
}
