using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Reti.NewCondeco.Repositories
{
    public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private DbContext _context { get; set; }
        private DbSet<TEntity> _dbSet { get; set; }

        protected DbContext Context
        {
            get
            {
                if (_context == null)
                    _context = ((EFUnitOfWork)GlobalUnitOfWork.Current).Context;
                return _context;
            }
        }

        protected DbSet<TEntity> DbSet
        {
            get
            {
                if (_dbSet == null)
                    _dbSet = this.Context.Set<TEntity>();
                return this._dbSet;
            }
        }

        public IQueryable<TEntity> GetQuery()
        {
            return DbSet;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return DbSet.ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> where)
        {
            return DbSet.Where<TEntity>(where);
        }

        public TEntity Single(Expression<Func<TEntity, bool>> where)
        {
            return DbSet.Where<TEntity>(where).SingleOrDefault();
        }

        public TEntity First(Expression<Func<TEntity, bool>> where)
        {
            return DbSet.Where<TEntity>(where).First();
        }

        public int Count()
        {
            return DbSet.Count();
        }

        public int Max(Func<TEntity, int> where)
        {
            return DbSet.Max<TEntity>(where);
        }

        public void DeleteAll(List<TEntity> listToDelete)
        {
            foreach (TEntity ent in listToDelete)
            {
                if (Context.Entry(ent).State == EntityState.Detached)
                {
                    DbSet.Attach(ent);
                }
                DbSet.Remove(ent);
            }
        }

        public virtual void Update(TEntity entity)
        {
            DbSet.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        public TEntity SingleWithNavProp(Expression<Func<TEntity, bool>> where, string propToLoad)
        {
            return DbSet.Where(where).Include(propToLoad).SingleOrDefault();
        }
    }
}
