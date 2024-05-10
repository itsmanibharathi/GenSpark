using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RequestTrackerModelLibrary;
using RequestTrackerModelLibrary.Exceptions;

namespace RequestTrackerDALLibrary
{
    public class EmployeeRepository : IRepository<int, Employee>
    {
        protected readonly RequestTrackerContext _context;

        public EmployeeRepository(RequestTrackerContext context) 
        {
            _context = context;
        }
        public async Task<Employee> Add(Employee entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<Employee> Get(int key)
        {
            var employee = await _context.Employees
                .SingleOrDefaultAsync(e => e.EmployeeId == key);
            if (employee == null)
            {
                throw new EmployeeIDNotFoundException(key);
            }
            return employee;
        }

        public virtual async Task<IList<Employee>> GetAll()
        {
            return await _context.Employees
                .ToListAsync() 
                ?? throw new EmptyDBException("Employee");
        }

        public async Task<Employee> Update(Employee entity)
        {
            var employee = await Get(entity.EmployeeId);
            if (employee == null)
                throw new EmployeeIDNotFoundException(entity.EmployeeId);
            
            _context.Entry<Employee>(employee).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<bool> Delete(int key)
        {
            var employee = await Get(key);
            if (employee == null)
            {
                throw new EmployeeIDNotFoundException(key);
            }
            try
            {
                _context.Employees.Remove(employee);

                var response = await _context.SaveChangesAsync();
                if (response != 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in deleting the employee", ex);
            }
            return false;

        }

    }
}
