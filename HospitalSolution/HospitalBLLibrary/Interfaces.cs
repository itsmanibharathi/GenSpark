using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalModuleLibrary;

namespace HospitalBLLibrary
{
    internal interface IDoctor
    {
        List<Doctor> GetAllDoctors();
        Doctor GetDoctor(int key);
        Doctor AddDoctor(Doctor item);
        Doctor UpdateDoctor(Doctor item);
        bool DeleteDoctor(int key);
    }
}
