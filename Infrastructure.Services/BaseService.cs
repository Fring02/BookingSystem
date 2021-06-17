using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class BaseService<TRepository, T, TId> : IModelService<TRepository, T, TId> where T : class
        where TRepository : IModelRepository<T, TId>
    {
        protected readonly TRepository _repository;

        protected BaseService(TRepository repository)
        {
            _repository = repository;
        }
        public virtual async Task<T> CreateAsync(T model)
        {
            return await _repository.CreateAsync(model).ConfigureAwait(false);
        }

        public virtual async Task<bool> DeleteAsync(T model)
        {
            return await _repository.DeleteAsync(model).ConfigureAwait(false);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync().ConfigureAwait(false);
        }

        public virtual async Task<T> GetByIdAsync(TId id)
        {
            return await _repository.GetByIdAsync(id).ConfigureAwait(false);
        }

        public virtual async Task<bool> UpdateAsync(T model)
        {
            return await _repository.UpdateAsync(model).ConfigureAwait(false);
        }
    }
}
