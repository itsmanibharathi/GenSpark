using Microsoft.EntityFrameworkCore;
using RequestTrackerModelLibrary;
using RequestTrackerModelLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerDALLibrary
{
    public class EmployeeRequstsRepository : EmployeeRepository
    {
        public EmployeeRequstsRepository(RequestTrackerContext context) : base(context)
        {
        }

        public override async Task<Employee> Get(int key)
        {
            var employee = await _context.Employees
                .Include(e=>e.RequestsRaised)
                .SingleOrDefaultAsync(e => e.EmployeeId == key);
            if (employee == null)
            {
                throw new EmployeeIDNotFoundException(key);
            }
            return employee;
        }

        public override async Task<IList<Employee>> GetAll()
        {
            return await _context.Employees
                .Include(e=>e.RequestsRaised)
                .ToListAsync() 
                ?? throw new EmptyDBException("Employee");
        }
    }
}
