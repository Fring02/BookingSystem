using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IModelRepository<T, in TId> where T : class
    {
        Task<T> CreateAsync(T model);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(TId id);
        Task<bool> UpdateAsync(T model);
        Task<bool> DeleteAsync(T model);
    }
}