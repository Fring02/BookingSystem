using Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IModelService<TRepository, T> where T : class where TRepository : IModelRepository<T>
    {
        Task<T> CreateAsync(T model);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task<bool> UpdateAsync(T model);
        Task<bool> DeleteAsync(T model);
    }
}