
using Application.Common.Models;
using Application.Common.Repositories;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System.Linq.Expressions;

namespace Persistence.Common
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly OffersDbContext Context;

        public BaseRepository(OffersDbContext context)
        {
            Context = context;
        }


        public virtual void CreateRange(List<T> entity)
        {
            Context.AddRange(entity);
        }

        public virtual void Update(T entity)
        {
            Context.Update(entity);
        }

        public virtual async Task<T> GetById(int Id, CancellationToken cancellationToken)
        {
            return await Context.Set<T>().Where(t => t.IsActive).AsNoTracking().FirstAsync(t => t.Id == Id, cancellationToken);
        }
        public virtual async Task<T?> GetDefaultById(int Id, CancellationToken cancellationToken)
        {
            return await Context.Set<T>().Where(t => t.IsActive).AsNoTracking().FirstOrDefaultAsync(t => t.Id == Id, cancellationToken);
        }
        public virtual async Task<PaginatedList<T>> GetPaginated(PaginationInput paginationInput, CancellationToken cancelationToken)
        {
            IQueryable<T> tempQuerable = Context.Set<T>().Where(t => t.IsActive == true).AsNoTracking();
               // .OrderByDescending(t => t.CreatedAt);
            if (paginationInput.GetAll != null && paginationInput.GetAll == true)
            {
                var items = await tempQuerable.ToListAsync(cancellationToken: cancelationToken);

                var count = await tempQuerable.CountAsync(cancellationToken: cancelationToken);

                return new PaginatedList<T>(items, count, paginationInput.CurrentPage, paginationInput.TakenRows);
            }
            else
            {
                var items = await tempQuerable.Skip((paginationInput.CurrentPage - 1) * paginationInput.TakenRows).Take(paginationInput.TakenRows).ToListAsync(cancellationToken: cancelationToken);

                var count = await tempQuerable.CountAsync(cancellationToken: cancelationToken);

                return new PaginatedList<T>(items, count, paginationInput.CurrentPage, paginationInput.TakenRows);
            }
        }


        public virtual async Task<T> Create(T entity, CancellationToken cancellationToken)
        {
            entity.CreatedAt = DateTime.Now;
            await Context.AddAsync(entity);
            return entity;
        }








        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Context.Set<T>()
                .Where(t => t.IsActive)
                .AsNoTracking()
                .ToListAsync();
        }

        public virtual async Task<T?> GetByIdAsync(int id)
        {
            return await Context.Set<T>()
                .Where(t => t.IsActive && t.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public virtual async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await Context.Set<T>()
                .Where(t => t.IsActive)
                .Where(predicate)
                .AsNoTracking()
                .ToListAsync();
        }

        public virtual async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await Context.Set<T>()
                .Where(t => t.IsActive)
                .Where(predicate)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public virtual async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate)
        {
            return await Context.Set<T>()
                .Where(t => t.IsActive)
                .Where(predicate)
                .AnyAsync();
        }

        public virtual async Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null)
        {
            var query = Context.Set<T>().Where(t => t.IsActive);
            
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            
            return await query.CountAsync();
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            entity.CreatedAt = DateTime.Now;
            entity.IsActive = true;
            await Context.AddAsync(entity);
            return entity;
        }

        public virtual async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            var entityList = entities.ToList();
            foreach (var entity in entityList)
            {
                entity.CreatedAt = DateTime.Now;
                entity.IsActive = true;
            }
            
            await Context.AddRangeAsync(entityList);
            return entityList;
        }

        public virtual async Task UpdateAsync(T entity)
        {
            entity.UpdatedAt = DateTime.Now;
            Context.Update(entity);
            await Task.CompletedTask;
        }

        public virtual async Task UpdateRangeAsync(IEnumerable<T> entities)
        {
            var entityList = entities.ToList();
            foreach (var entity in entityList)
            {
                entity.UpdatedAt = DateTime.Now;
            }
            
            Context.UpdateRange(entityList);
            await Task.CompletedTask;
        }

        public virtual async Task DeleteAsync(T entity)
        {
            entity.IsActive = false;
            entity.DeletedAt = DateTime.Now;
            Context.Update(entity);
            await Task.CompletedTask;
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await Context.Set<T>().FirstOrDefaultAsync(t => t.Id == id);
            if (entity != null)
            {
                entity.IsActive = false;
                entity.DeletedAt = DateTime.Now;
                Context.Update(entity);
            }
            await Task.CompletedTask;
        }

        public virtual async Task DeleteRangeAsync(IEnumerable<T> entities)
        {
            var entityList = entities.ToList();
            foreach (var entity in entityList)
            {
                entity.IsActive = false;
                entity.DeletedAt = DateTime.Now;
            }
            
            Context.UpdateRange(entityList);
            await Task.CompletedTask;
        }

        public virtual async Task DeleteRangeAsync(IEnumerable<int> ids)
        {
            var entities = await Context.Set<T>()
                .Where(t => ids.Contains(t.Id))
                .ToListAsync();
                
            foreach (var entity in entities)
            {
                entity.IsActive = false;
                entity.DeletedAt = DateTime.Now;
            }
            
            Context.UpdateRange(entities);
            await Task.CompletedTask;
        }

        public virtual async Task<IEnumerable<T>> GetAllWithIncludesAsync(params Expression<Func<T, object>>[] includes)
        {
            var query = Context.Set<T>().Where(t => t.IsActive).AsNoTracking();
            
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            
            return await query.ToListAsync();
        }

        public virtual async Task<T?> GetByIdWithIncludesAsync(int id, params Expression<Func<T, object>>[] includes)
        {
            var query = Context.Set<T>()
                .Where(t => t.IsActive && t.Id == id)
                .AsNoTracking();
            
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            
            return await query.FirstOrDefaultAsync();
        }

        public virtual async Task<IEnumerable<T>> FindWithIncludesAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            var query = Context.Set<T>()
                .Where(t => t.IsActive)
                .Where(predicate)
                .AsNoTracking();
            
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            
            return await query.ToListAsync();
        }
    }
}