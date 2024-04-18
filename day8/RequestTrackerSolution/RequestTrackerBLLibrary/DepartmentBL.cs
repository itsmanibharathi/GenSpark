using RequestTrackerDALLibrary;
using RequestTrakerModelLibrary;

namespace RequestTrackerBLLibrary
{
    public class DepartmentBL : IDepartmentService
    {
        readonly IRepository<int, Department> _departmentRepository;
        public DepartmentBL()
        {
            _departmentRepository = new DepartmentRepository();
        }

        public int AddDepartment(Department department)
        {
            var result = _departmentRepository.Add(department);
            
            if(result != null)
            {
                return result.Id;
            }
            throw new DuplicateDepartmentNameException();
        }


        public Department ChangeDepartmentName(string departmentOldName, string departmentNewName)
        {
            var department = _departmentRepository.GetAll();
            foreach (var item in department)
            {
                if (item.Name == departmentOldName)
                {
                    item.Name = departmentNewName;
                    _departmentRepository.Update(item);
                    return item;
                }
            }
            throw new DepartmentNotFoundException();
        }

        public Department GetDepartmentById(int id)
        { 
            var department = _departmentRepository.GetById(id);
            if (department != null)
            {
                return department;
            }
            else
            {
                throw new DepartmentNotFoundException();
            }
        }

        public Department GetDepartmentByName(string departmentName)
        {
            throw new NotImplementedException();
        }

        public int GetDepartmentHeadId(int departmentId)
        {
            var department = _departmentRepository.Get(departmentId);
            if (department != null)
            {
                return department.Department_Head_Id;
            }
            else
            {
                throw new DepartmentNotFoundException();
            }
        }
    }
}
