using Core.DataAccess.Abstract;
using Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Concrete
{
    public class Repository<TEntity, TContext> : IBaseRepository<TEntity>
        where TEntity : class,IEntity,new()
        where TContext:IdentityDbContext<AppUser>

    {
        private readonly TContext _context;

        public Repository(TContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> exp = null, params string[] includes)
        {
            IQueryable<TEntity> query = GetQuery(includes);
            return exp==null? await query.ToListAsync() : await  query.Where(exp).ToListAsync();
        }

        public TEntity GetById(int id)
        {
            TEntity entity= _context.Set<TEntity>().Find(id); ;
            return entity;
        }

        public async Task SaveAsync()
        {
          await  _context.SaveChangesAsync();
        }

        public void Update(TEntity entity)
        {
            _context.Update(entity);
        }
        private IQueryable<TEntity> GetQuery(string[] includes)
        {
            IQueryable<TEntity> query= _context.Set<TEntity>();
            if (includes != null)
            {
                foreach (var item in includes)
                {
                    query.Include(item);
                }
            }
            return query;
                
        }
    }
}
