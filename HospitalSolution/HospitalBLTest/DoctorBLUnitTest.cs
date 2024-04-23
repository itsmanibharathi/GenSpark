

using HospitalBLLibrary;
using HospitalDALLibrary;
using HospitalModuleLibrary;

namespace HospitalBLTest
{
    public class DoctorBLUnitTest
    {
        IRepository<int, Doctor> _repository;
        DoctorBL doctorBL;
        [SetUp]
        public void Setup()
        {
            _repository = new DoctorRepository();
            doctorBL = new DoctorBL(_repository);
            doctorBL.Add(new Doctor("Mani", "Surgery"));

        }

        [Test]
        public void AddSuccessTest()
        {
            Doctor doctor = new Doctor("kali", "Surgery");
            Doctor result = doctorBL.Add(doctor);
            Assert.AreEqual(2, result.DoctorID);
        }

        [Test]
        public void AddDoctorFailureTest()
        {
            Doctor doctor = new Doctor("kali", "Surgery");
            Doctor result = doctorBL.Add(doctor);
            Assert.AreNotEqual(1, result.DoctorID);
        }
        [Test]
        public void AddDocter_WhenDoctorDetailsAlreadyExists_ShouldReturnException()
        {
            Doctor doctor = new Doctor("kali", "Surgery");
            Doctor result = doctorBL.Add(doctor);
            var ex = Assert.Throws<DuplicateDoctorDetailsException>(() => doctorBL.Add(doctor));
            Assert.AreEqual("Doctor Details already exists", ex.Message);
        }

        [Test]
        public void GetDoctorByID() {             
            Doctor doctor = new Doctor("kali", "Surgery");
            Doctor result = doctorBL.Add(doctor);
            Doctor result1 = doctorBL.Get(result.DoctorID);
            Assert.AreEqual(result, result1);
        }

        [Test]
        public void GetDoctorByID_WhenDoctorIDIsNotPresent_ShouldReturnException()
        {
            Doctor doctor = new Doctor("kali", "Surgery");
            Doctor result = doctorBL.Add(doctor);
            Assert.Throws<KeyNotFoundException>(() => doctorBL.Get(100));
        }
        [Test]
        public void GetAllDoctor()
        {
            Doctor doctor = new Doctor("kali", "Surgery");
            Doctor result = doctorBL.Add(doctor);
            List<Doctor> result1 = doctorBL.GetAll();
            Assert.AreEqual(2, result1.Count);
        }

        [Test]
        public void GetAllDoctorFailure()
        {
            Doctor doctor = new Doctor("kali", "Surgery");
            Doctor result = doctorBL.Add(doctor);
            List<Doctor> result1 = doctorBL.GetAll();
            Assert.AreNotEqual(1, result1.Count);
        }

        [Test]
        public void GetAllDoctor_EmptyDataBaseException()
        {
            Assert.Throws<EmptyDataBaseException>(() => new DoctorBL(new DoctorRepository()).GetAll());
        }

        [Test]
        public void UpdateDoctor()
        {
            Doctor doctor = new Doctor("kali", "Surgery");
            Doctor result = doctorBL.Add(doctor);
            Doctor doctor1 = new Doctor("kali", "Surgery");
            doctor1.DoctorID = result.DoctorID;
            Doctor result1 = doctorBL.Update(doctor1);
            Assert.AreEqual(result1, doctor1);
        }
        [Test]
        public void UpdateDoctor_WhenDoctorIDIsNotPresent()
        {
            Doctor doctor = new Doctor("kali", "Surgery");
            Doctor result = doctorBL.Add(doctor);
            Doctor doctor1 = new Doctor("kali..", "Surgery");
            doctor1.DoctorID = result.DoctorID;
            Assert.Throws<DoctorIdNotFoundException>(() => doctorBL.Update(new Doctor("kali", "Surgery")));
        }

        [Test]
        public void UpdateDoctor_EmptyDataBaseException()
        {
            Assert.Throws<EmptyDataBaseException>(() => new DoctorBL(new DoctorRepository()).Update(new Doctor("kali", "Surgery")));
        }
        [Test]
        public void DeleteDoctor()
        {
            Doctor doctor = new Doctor("kali", "Surgery");
            Doctor result = doctorBL.Add(doctor);
            bool result1 = doctorBL.Delete(result.DoctorID);
            Assert.AreEqual(true, result1);
        }
        [Test]
        public void DeleteDoctor_WhenDoctorIDIsNotPresent()
        {
            Doctor doctor = new Doctor("kali", "Surgery");
            Doctor result = doctorBL.Add(doctor);
            Assert.Throws<DoctorIdNotFoundException>(() => doctorBL.Delete(100));
        }
        [Test]
        public void DeleteDoctor_EmptyDataBaseException()
        {
            Assert.Throws<EmptyDataBaseException>(() => new DoctorBL(new DoctorRepository()).Delete(1));
        }

        [Test]
        public void DeleteDoctorFailure()
        {
            Doctor doctor = new Doctor("kali", "Surgery");
            Doctor result = doctorBL.Add(doctor);
            bool result1 = doctorBL.Delete(result.DoctorID);
            Assert.AreNotEqual(false, result1);
        }
    }
}