using Microsoft.EntityFrameworkCore;
using PizzaHutAPI.Interfaces;
using PizzaHutAPI.Models;
using PizzaHutAPI.Context;
using PizzaHutAPI.Exceptions;

namespace UserHutAPI.Repositories
{
    public class UserRepository : IRepository<int, User>
    {
        private readonly DBPizzaHutContext _context;
        public UserRepository(DBPizzaHutContext context)
        {
            _context = context;
        }
        public async Task<User> Add(User item)
        {
            try
            {
                _context.Users.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                throw new UnableToDoneActionException("Unable to Insert the new User");
            }
        }


        public async Task<User> Get(int key)
        {
            try
            {
                return (await _context.Users.SingleOrDefaultAsync(p => p.Id == key)) ?? throw new NoUserInThisID(key);
            }
            catch (Exception ex)
            {
                throw new UnableToDoneActionException("Unable to Get the User");
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
            catch (ArgumentNullException)
            {
                throw new EmptyDBException("User");
            }
            catch (OperationCanceledException ex)
            {
                throw new UnableToDoneActionException("Unable to list All the User");
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
                throw new AlreadyUpToDateException(item.Id);
            }
            catch (Exception ex)
            {
                throw new UnableToDoneActionException("Unable to Update the User");
            }
        }
        public async Task<bool> Delete(int key)
        {
            var piza = Get(key);
            _context.Remove(piza);
            try
            {
                var res = await _context.SaveChangesAsync();
                if (res > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new UnableToDoneActionException("Unable to Delete the User");
            }
        }
    }
}
