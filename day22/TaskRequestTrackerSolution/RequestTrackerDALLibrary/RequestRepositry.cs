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
    public class RequestRepositry : IRepository<int, Request>
    {
        protected readonly RequestTrackerContext _context;
        public RequestRepositry(RequestTrackerContext context)
        {
            _context = context;
        }
        public async Task<Request> Add(Request entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<Request> Get(int key)
        {
            var request = await _context.Requests.SingleOrDefaultAsync(r => r.RequestNumber == key);
            if(request == null)
            {
                throw new RequestNumberNotFoundException(key);
            }
            return request;
        }

        public async Task<IList<Request>> GetAll()
        {
            return await _context.Requests.ToListAsync() ?? throw new EmptyDBException("Request");
        }

        public async Task<bool> Delete(int key)
        {
            var request = await Get(key);
            if (request == null)
            {
                throw new RequestNumberNotFoundException(key);
            }
            _context.Requests.Remove(request);
            try
            {
                var response =await _context.SaveChangesAsync();
                if (response == 0)
                {
                    throw new Exception("Error in deleting the request");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in deleting the request", ex);
            }
            return true;
        }


        public async Task<Request> Update(Request entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Request");
            }
            var request = Get(entity.RequestNumber);
            if(request == null)
            {
                throw new RequestNumberNotFoundException(entity.RequestNumber);
            }
            try
            {
                _context.Entry<Request>(entity).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error in updating the request", ex);
            }

            return await Get(entity.RequestNumber);
        }
    }
}
