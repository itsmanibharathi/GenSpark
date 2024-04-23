using HospitalBLLibrary;
using HospitalDALLibrary;
using HospitalModuleLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalBLTest
{

    public class patientBLUnitTest
    {
        PatientRepository _patientRepository;
        PatientBL _patientBL;

        [SetUp]
        public void Setup()
        {
            _patientRepository = new PatientRepository();
            _patientBL = new PatientBL(_patientRepository);
            _patientBL.Add(new Patient("Mani","Male",22,"Erode","123456"));
        }

        [Test]
        public void AddPatientTest()
        {
            var result = _patientBL.Add(new Patient("kali", "Male", 22, "Erode", "123456"));
            Assert.AreEqual(102, result.PatientID);
        }
        [Test]
        public void AddPatientFailureTest()
        {
            var result = _patientBL.Add(new Patient("Kali", "Male", 22, "Erode", "123456"));
            Assert.AreNotEqual(101, result.PatientID);
        }

        [Test]
        public void AddPatient_WhenPatientDetailsAlreadyExists_ShouldReturnException()
        {
            var result = _patientBL.Add(new Patient("Mani", "Male", 22, "Erode", "123456"));
            Assert.Throws<DuplicatePatientDetailsException>(() => _patientBL.Add(result));

        }

        [Test]
        public void GetPatientByID()
        {
            var result = _patientBL.Add(new Patient("Mani", "Male", 22, "Erode", "123456"));
            var result1 = _patientBL.Get(result.PatientID);
            Assert.AreEqual(result, result1);
        }


        [Test]
        public void GetPatientByID_WithKeyNotFoundException()
        {
            Assert.Throws<KeyNotFoundException>(() => _patientBL.Get(100));
        }

        [Test]
        public void GetAllPatient()
        {
            var result = _patientBL.GetAll();
            Assert.AreEqual(result.Count,1);
        }
        [Test]
        public void GetAllPatient_WithEmptyDataBaseException()
        {
            Assert.Throws<EmptyDataBaseException>(() => new PatientBL(new PatientRepository()).GetAll());
        }
        [Test]
        public void DeletePatient()
        {
            var result = _patientBL.Delete(101);
            Assert.AreEqual(true, result);
        }

        [Test]
        public void DeletePatient_WithPatientIdNotFoundException()
        {
            Assert.Throws<PatientIdNotFoundException>(() => _patientBL.Delete(100));
        }
        [Test]
        public void DeletePatientFailure()
        {
            var result = _patientBL.Delete(101);
            Assert.AreNotEqual(false, result);
        }
    }
}
