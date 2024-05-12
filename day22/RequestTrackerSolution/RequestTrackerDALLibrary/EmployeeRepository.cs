using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RequestTrackerModelLibrary;
using RequestTrackerModelLibrary.Exceptions;

namespace RequestTrackerDALLibrary
{
    public class EmployeeRepository : IRepository<int, Employee>
    {
        protected readonly RequestTrackerContext _context;
        /// <summary>
        /// Employee Repository Constructor
        /// </summary>
        /// <param name="context">o </param>
        public EmployeeRepository(RequestTrackerContext context) 
        {
            _context = context;
        }
        /// <summary>
        /// Add Employee to the database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<Employee> Add(Employee entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        /// <summary>
        /// Get Employee by Id
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        /// <exception cref="EmployeeIdNotFoundException"></exception>
        public virtual async Task<Employee> Get(int key)
        {
            var employee = _context.Employees.SingleOrDefault(e => e.Id == key);
            if (employee == null)
            {
                throw new EmployeeIdNotFoundException(key);
            }
            return employee;
        }

        public virtual async Task<IList<Employee>> GetAll()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> Update(Employee entity)
        {
            var employee = await Get(entity.Id);
            if (employee != null)
            {
                _context.Entry<Employee>(employee).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return await Get(entity.Id);
        }
        public async Task<bool> Delete(int key)
        {
            var employee = await Get(key);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
