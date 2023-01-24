using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Abstract
{
    public interface IBaseRepository<TEntity>
    {
        public  Task<List<TEntity>> GetAllAsync( Expression<Func<TEntity,bool>> exp = null,params string[] includes);
        public  TEntity GetById(int id );
        public Task CreateAsync(TEntity entity);    
        public void Delete(TEntity entity);
        public void Update(TEntity entity);
       public  Task SaveAsync();
    }
}
