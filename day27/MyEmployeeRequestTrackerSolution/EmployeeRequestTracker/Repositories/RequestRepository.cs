
using EmployeeRequestTracker.Context;
using EmployeeRequestTracker.Exceptions;
using EmployeeRequestTracker.Interfaces;
using EmployeeRequestTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace RequestRequestTracker.Repositories
{
    public class RequestRepository : IRepository<int,Request>
    {
        private readonly DBEmpReqTrackerContext _context;

        public RequestRepository(DBEmpReqTrackerContext context)
        {
            _context = context;
        }

        public async Task<Request> Add(Request item)
        {
            try
            {
                await _context.Requests.AddAsync(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                throw new UnableToDoneActionException("Unable to insert the new Request");
            }
        }

        public async Task<Request> Get(int key)
        {
            //try
            //{
            //    return (await _context.Requests.SingleOrDefaultAsync(p => p.RequestId == key))
            //        ?? throw new NoRequestInThisID(key);
            //}
            //catch (NoRequestInThisID)
            //{
            //    throw;
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("Exception caught: " + ex.Message);
            //    throw new UnableToDoneActionException("Unable to get the Request");
            //}
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Request>> Get()
        {
            try
            {
                var res = await _context.Requests.ToListAsync();
                if (res.Count > 0)
                    return res;
                throw new EmptyDBException("Request");
            }
            catch (EmptyDBException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new UnableToDoneActionException("Unable to list all Requests");
            }
        }

        public async Task<Request> Update(Request item)
        {
            try
            {
                _context.Requests.Update(item);
                var res = await _context.SaveChangesAsync();
                if (res > 0)
                    return item;
                throw new AlreadyUpToDateException(item.RequestId);
            }
            catch (AlreadyUpToDateException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new UnableToDoneActionException("Unable to update the Request");
            }
        }

        public async Task<bool> Delete(int key)
        {
            //    try
            //    {
            //        var Request = await Get(key);
            //        _context.Requests.Remove(Request);
            //        var res = await _context.SaveChangesAsync();
            //        return res > 0;
            //    }
            //    catch (NoRequestInThisID)
            //    {
            //        throw;
            //    }
            //    catch (Exception ex)
            //    {
            //        throw new UnableToDoneActionException("Unable to delete the Request");
            //    }
            throw new NotImplementedException();
        }

    }
}
