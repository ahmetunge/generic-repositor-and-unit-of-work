using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Core.Entities;
using Api.Core.Specifications;

namespace Api.Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);

        Task<IReadOnlyList<T>> ListAllAsync();

        Task<T> GetEntityWithSpec(ISpecification<T> spec);
        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        Task<int> CountAsync(ISpecification<T> spec);
    }
}