using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Interfaces.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class BaseRepository<T> : IModelRepository<T> where T : class
    {
        protected readonly BookingContext _context;

        public BaseRepository(BookingContext context)
        {
            _context = context;
        }

        public virtual async Task<T> CreateAsync(T model)
        {
            await _context.Set<T>().AddAsync(model).ConfigureAwait(false);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return model;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync().ConfigureAwait(false);
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id).ConfigureAwait(false);
        }

        public async Task<bool> UpdateAsync(T model)
        { 
            _context.Set<T>().Update(model);
            return await _context.SaveChangesAsync().ConfigureAwait(false) > 0;
        }

        public async Task<bool> DeleteAsync(T model)
        {
            _context.Set<T>().Remove(model);
            return await _context.SaveChangesAsync().ConfigureAwait(false) > 0;
        }
    }
}