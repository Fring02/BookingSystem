using Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Core.Models;

namespace Domain.Interfaces.Services
{
    public interface IModelService<TRepository, T, TId> where T : class where TRepository : IModelRepository<T, TId>
    {
        Task<T> CreateAsync(T model);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(TId id);
        Task<bool> UpdateAsync(T model);
        Task<bool> DeleteAsync(T model);
    }
}