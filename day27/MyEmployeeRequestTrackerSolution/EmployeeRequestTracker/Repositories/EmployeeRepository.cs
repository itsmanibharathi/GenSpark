using EmployeeRequestTracker.Context;
using EmployeeRequestTracker.Exceptions;
using EmployeeRequestTracker.Interfaces;
using EmployeeRequestTracker.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeRequestTracker.Repositories
{
    public class EmployeeRepository : IRepository<int, Employee>
    {
        private readonly DBEmpReqTrackerContext _context;

        public EmployeeRepository(DBEmpReqTrackerContext context)
        {
            _context = context;
        }

        public async Task<Employee> Add(Employee item)
        {
            try
            {
                if (!await IsDuplicate(item))
                {
                    await _context.Employees.AddAsync(item);
                    await _context.SaveChangesAsync();
                    return item;
                }
                throw new AlreadyExistsException();
                
            }
            catch (AlreadyExistsException ex)
            {
                throw new AlreadyExistsException();
            }
            catch (Exception ex)
            {
                throw new UnableToDoneActionException("Unable to insert the new employee");
            }
        }

        private async Task<bool> IsDuplicate(Employee item)
        {
            return await _context.Employees.AnyAsync(p => p.Email == item.Email);
        }

        public async Task<Employee> Get(int key)
        {
            try
            {
                return (await _context.Employees.SingleOrDefaultAsync(p => p.EmployeeId == key))
                    ?? throw new NoEmployeeInThisID(key);
            }
            catch (NoEmployeeInThisID )
            {
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught: " + ex.Message);
                throw new UnableToDoneActionException("Unable to get the employee");
            }
        }

        public async Task<IEnumerable<Employee>> Get()
        {
            try
            {
                var res = await _context.Employees.ToListAsync();
                if (res.Count > 0)
                    return res;
                throw new EmptyDBException("Employee");
            }
            catch (EmptyDBException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new UnableToDoneActionException("Unable to list all employees");
            }
        }

        public async Task<Employee> Update(Employee item)
        {
            try
            {
                _context.Employees.Update(item);
                var res = await _context.SaveChangesAsync();
                if (res > 0)
                    return item;
                throw new AlreadyUpToDateException(item.EmployeeId);
            }
            catch (AlreadyUpToDateException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new UnableToDoneActionException("Unable to update the employee");
            }
        }

        public async Task<bool> Delete(int key)
        {
            try
            {
                var employee = await Get(key);
                _context.Employees.Remove(employee);
                var res = await _context.SaveChangesAsync();
                return res > 0;
            }
            catch (NoEmployeeInThisID)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new UnableToDoneActionException("Unable to delete the employee");
            }
        }
    }
}
