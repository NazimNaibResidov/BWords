using BWords.Api.Application.Interfaces.Repostoryes;
using BWords.Api.Domain.Models;
using BWords.infrastructure.Persistent.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BWords.infrastructure.Persistent.Repostors
{
    public class GenericRepstory<T> : IGenericRepstory<T> where T : BaseEntity
    {
        private readonly DbContext _Dbcontext;
        private DbSet<T> entity;
        public GenericRepstory(DbContext Dbcontext)
        {
            this._Dbcontext = Dbcontext;
            //?? throw new ArgumentNullException(nameof(Dbcontext));
            entity = _Dbcontext.Set<T>();
        }

        public virtual IQueryable<T> AsQueryable()
        {
            var data = entity;
            return entity.AsQueryable();
        }
       

        #region :ADDED::
        public virtual int Add(T entity)
        {
            this.entity.Add(entity);
            return _Dbcontext.SaveChanges();
        }

        public virtual int Add(IEnumerable<T> entity)
        {
            this.entity.AddRange(entity);
            return _Dbcontext.SaveChanges();
        }

        public virtual async Task<int> AddAsync(T entity)
        {
            await this.entity.AddAsync(entity);
            return await _Dbcontext.SaveChangesAsync();
        }

        public virtual async Task<int> AddAsync(IEnumerable<T> entity)
        {
            await this.entity.AddRangeAsync(entity);
            return await _Dbcontext.SaveChangesAsync();
        }
        #endregion

        #region ::UPDATE::
        public virtual int Update(T entity)
        {
            this.entity.Attach(entity);
            _Dbcontext.Entry(entity).State = EntityState.Modified;
            return _Dbcontext.SaveChanges();

        }

        public virtual async Task<int> UpdateAsync(T entity)
        {
            this.entity.Attach(entity);
            _Dbcontext.Entry(entity).State = EntityState.Modified;
            return await _Dbcontext.SaveChangesAsync();
        }
        #endregion

        #region ::DELETE::
        public virtual int Delete(T entity)
        {
            if (_Dbcontext.Entry(entity).State==EntityState.Detached)
            {
                this.entity.Attach(entity);
            }
            this.entity.Remove(entity);
            return  _Dbcontext.SaveChanges();
        }
        public int Delete(Guid id)
        {
            var entity = this.entity.Find(id);
            return Delete(entity);
        }

        public virtual async Task<int> DeleteAsync(T entity)
        {
            if (_Dbcontext.Entry(entity).State == EntityState.Detached)
            {
                this.entity.Attach(entity);
            }
            this.entity.Remove(entity);
            return await _Dbcontext.SaveChangesAsync();
        }

        public virtual async Task<int> DeleteAsync(Guid Id)
        {
            var entity =await this.entity.FindAsync(Id);
            return await DeleteAsync(entity);
        }

        public virtual bool DeleteRange(Expression<Func<T, bool>> peridicate)
        {
            _Dbcontext.RemoveRange(entity.Where(peridicate));
            return _Dbcontext.SaveChanges() > 0;
        }

        public virtual async Task<bool> DeleteRangeAsync(Expression<Func<T, bool>> peridicate)
        {
            _Dbcontext.RemoveRange(entity.Where(peridicate));
            return await _Dbcontext.SaveChangesAsync() > 0;
        }
        #endregion

        #region ::AddOrUpdate::
        public virtual bool AddOrUpdate(T entity)
        {
            if (this.entity.Local.Any(i => EqualityComparer<Guid>.Default.Equals(i.Id, entity.Id)))
                _Dbcontext.Update(entity);
            return _Dbcontext.SaveChanges() > 0;
            
        }

        public virtual async Task<bool> AddOrUpdateAsync(T entity)
        {

            if (this.entity.Local.Any(i => EqualityComparer<Guid>.Default.Equals(i.Id, entity.Id)))
                _Dbcontext.Update(entity);
            return await _Dbcontext.SaveChangesAsync() > 0;
        }
        #endregion

        #region ::GET::
        public virtual IQueryable<T> Get(Expression<Func<T, bool>> predicate, bool noTracking = true, params Expression<Func<T, object>>[] includes)
        {
            var query = entity.AsQueryable();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            query = ApplyIncludes(query, includes);
            if (noTracking)
                query = query.AsNoTracking();
            return query;
        }
        public virtual IEnumerable<T> Get()
        {
            var reuslt= _Dbcontext.Set<T>().ToList();
            return reuslt;
        }
        public virtual async Task<List<T>> GetList(Expression<Func<T, bool>> peridicate, bool noTracking = true, IOrderedQueryable<T> order = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = entity;
            if (peridicate != null)
            {
                query = query.Where(peridicate);
            }
            foreach (Expression<Func<T, object>> include in includes)
            {
                query = query.Include(include);
            }
            if (order != null)
            {

            }
            if (noTracking)
                query = query.AsNoTracking();
            return await query.ToListAsync();

        }
        public virtual async Task<T> GetByIdAsync(Guid id, bool noTracking = true, params Expression<Func<T, object>>[] includes)
        {
            T found = await this.entity.FindAsync(id);
            if (found == null)
            {
                return null;
            }
            if (noTracking)
                _Dbcontext.Entry(found).State = EntityState.Detached;
            foreach (Expression<Func<T, object>> include in includes)
            {
                _Dbcontext.Entry(found).Reference(include).Load();
            }
            return found;
        }
        public virtual async Task<T> GetSingleAsync(Expression<Func<T, bool>> peridicate, bool noTracking = true, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = entity;
            if (peridicate!=null)
            {
                query = query.Where(peridicate);
            }
            query = ApplyIncludes(query, includes);
            if (noTracking)
                query = query.AsNoTracking();
            return await query.SingleOrDefaultAsync();
        }
        public virtual async Task<List<T>> GetAll(bool noTracking = true)
        {

            IQueryable<T> query = entity;

            if (noTracking)
                query = query.AsNoTracking();
            return await query.ToListAsync();

        }

        #endregion

        #region ::BULK::

        public  virtual async Task BulkAdd(IEnumerable<T> entitys)
        {
            if (entitys==null&&!entitys.Any())
              await Task.CompletedTask;
              await entity.AddRangeAsync(entitys);
              await _Dbcontext.SaveChangesAsync();
        }

        public virtual Task BulkDelete(Expression<Func<T, bool>> peridicat)
        {
            if (peridicat==null)
                return Task.CompletedTask;
            _Dbcontext.Remove(peridicat);
            return _Dbcontext.SaveChangesAsync();

        }

        public virtual async Task BulkDelete(IEnumerable<T> entitys)
        {
            if (entity==null&&!await entity.AnyAsync())
                await Task.CompletedTask;
            _Dbcontext.RemoveRange(entitys);
            await _Dbcontext.SaveChangesAsync();
        }

        public virtual  Task BulkDeleteById(IEnumerable<Guid> Id)
        {
            if (Id == null && !Id.Any())
                return Task.CompletedTask;
            _Dbcontext.RemoveRange(entity.Where(i => Id.Contains(i.Id)));
            return  _Dbcontext.SaveChangesAsync();
        }

        public virtual async Task BulkUpdate(IEnumerable<T> entitys)
        {
            if (entity == null && !await entity.AnyAsync())
                await Task.CompletedTask;
            entity.UpdateRange(entitys);
            await _Dbcontext.SaveChangesAsync();
        }

        #endregion








        private static IQueryable<T> ApplyIncludes(IQueryable<T> query, params Expression<Func<T, object>>[] includes)
        {
            if (query != null)
            {
                foreach (var includeitem in includes)
                {
                    query = query.Include(includeitem);
                }
            }
            return query;
        }
        
        public Task<int> SaveChangesAsync()
        {
           return _Dbcontext.SaveChangesAsync();
        }
        public int SaveChanges()
        {
            return _Dbcontext.SaveChanges();
        }



    }
}
