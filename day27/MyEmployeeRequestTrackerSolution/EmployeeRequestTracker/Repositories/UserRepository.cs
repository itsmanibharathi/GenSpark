
using EmployeeRequestTracker.Context;
using EmployeeRequestTracker.Exceptions;
using EmployeeRequestTracker.Interfaces;
using EmployeeRequestTracker.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UserRequestTracker.Repositories
{
    public class UserRepository : IRepository<int, User>
    {
        private readonly DBEmpReqTrackerContext _context;

        public UserRepository(DBEmpReqTrackerContext context)
        {
            _context = context;
        }

        public async Task<User> Add(User item)
        {
            try
            {
                if (!await IsDuplicate(item))
                {
                    await _context.Users.AddAsync(item);
                    await _context.SaveChangesAsync();
                    return item;
                }
                throw new AlreadyExistsException();

            }
            catch (AlreadyExistsException ex)
            {
                throw new AlreadyExistsException();
            }
            catch (Exception)
            {
                throw new UnableToDoneActionException("Unable to insert the new User");
            }
        }

        private async Task<bool> IsDuplicate(User item)
        {
            return await _context.Users.AnyAsync(p => p.EmployeeId == item.EmployeeId);
        }

        public async Task<User> Get(int key)
        {
            try
            {
                return (await _context.Users.Include(u => u.employee).SingleOrDefaultAsync(p => p.EmployeeId == key))
                    ?? throw new NoUserInThisID(key);
            }
            catch (NoUserInThisID)
            {
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught: " + ex.Message);
                throw new UnableToDoneActionException("Unable to get the User");
            }
        }

        public async Task<IEnumerable<User>> Get()
        {
            try
            {
                var res = await _context.Users.ToListAsync();
                if (res.Count > 0)
                    return res;
                throw new EmptyDBException("User");
            }
            catch (EmptyDBException)
            {
                throw;
            }
            catch (Exception)
            {
                throw new UnableToDoneActionException("Unable to list all Users");
            }
        }

        public async Task<User> Update(User item)
        {
            try
            {
                _context.Users.Update(item);
                var res = await _context.SaveChangesAsync();
                if (res > 0)
                    return item;
                throw new AlreadyUpToDateException(item.EmployeeId);
            }
            catch (AlreadyUpToDateException)
            {
                throw;
            }
            catch (Exception)
            {
                throw new UnableToDoneActionException("Unable to update the User");
            }
        }

        public async Task<bool> Delete(int key)
        {
            try
            {
                var User = await Get(key);
                _context.Users.Remove(User);
                var res = await _context.SaveChangesAsync();
                return res > 0;
            }
            catch (NoUserInThisID)
            {
                throw;
            }
            catch (Exception)
            {
                throw new UnableToDoneActionException("Unable to delete the User");
            }
        }
    }
}
