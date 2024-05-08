using RequestTrackerDALLibrary;
using RequestTrakerModelLibrary;

namespace RequestTrackerBLLibrary
{
    public class DepartmentBL
    {
        readonly IRepository<int, Department> _repository;
        public DepartmentBL()
        {
            _repository = new DepartmentRepository();
        }

        public Department AddDepartment()
        {
            try
            {
                Department department = new Department();
                department.BuildDepartmentFromConsole();
                return _repository.Add(department);
            }
            catch (DuplicateDepartmentNameException)
            {
                throw new DuplicateDepartmentNameException();
            }
        }

        public List<Department> GetAllDepartments()
        {
            try
            {
                return _repository.GetAll();
            }
            catch (EmptyDBException)
            {
                throw new EmptyDBException();
            }
        }
        public Department GetDepartment()
        {
            try
            {
                int id = Department.GetDepartmentIdFromConsole();
                return _repository.Get(id);
            }
            catch (DepartmentNotFoundException)
            {
                throw new DepartmentNotFoundException();
            }
        }
        public Department RemoveDepartment()
        {
            try
            {
                int id = Department.GetDepartmentIdFromConsole();
                return _repository.Delete(id);
            }
            catch (DepartmentNotFoundException)
            {
                throw new DepartmentNotFoundException();
            }
        }

        public Department UpdateDepartment()
        {
            try
            {
                Department department = new Department();
                department.BuildDepartmentFromConsole();
                return _repository.Update(department);
            }
            catch (DepartmentNotFoundException)
            {
                throw new DepartmentNotFoundException();
            }
        }
        

    }
}
