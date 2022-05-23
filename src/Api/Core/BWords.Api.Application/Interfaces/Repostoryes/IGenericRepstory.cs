using BWords.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BWords.Api.Application.Interfaces.Repostoryes
{

    public interface IGenericRepstory<T> where T:BaseEntity
    {
        Task<int> AddAsync(T entity);
        int Add(T entity);
        
       
        int Add(IEnumerable<T> entity);
        Task<int> AddAsync(IEnumerable<T> entity);

        Task<int> UpdateAsync(T entity);
        int Update(T entity);

        Task<int> DeleteAsync(T entity);
        int Delete(T entity);

        Task<int> DeleteAsync(Guid Id);
        int Delete(Guid id);

        bool DeleteRange(Expression<Func<T, bool>> peridicate);
        Task<bool> DeleteRangeAsync(Expression<Func<T, bool>> peridicate);

        bool AddOrUpdate(T entity);
        Task<bool> AddOrUpdateAsync(T entity);
        IEnumerable<T> Get();
        IQueryable<T> AsQueryable();

        Task<List<T>> GetAll(bool noTracking = true);

        Task<List<T>> GetList(Expression<Func<T, bool>> peridicate, bool noTracking = true, IOrderedQueryable<T> order = null, params Expression<Func<T, object>>[] includes);
        Task<T> GetByIdAsync(Guid id, bool noTracking = true, params Expression<Func<T, object>>[] includes);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> peridicate, bool noTracking = true, params Expression<Func<T, object>>[] includes);
        IQueryable<T> Get(Expression<Func<T, bool>> peridicate, bool noTracking = true, params Expression<Func<T, object>>[] includes);
        Task BulkDeleteById(IEnumerable<Guid> Id);
        Task BulkDelete(Expression<Func<T, bool>> peridicat);
        Task BulkDelete(IEnumerable<T> entitys);
        Task BulkUpdate(IEnumerable<T> entitys);
        Task BulkAdd(IEnumerable<T> entitys);





    }
}
