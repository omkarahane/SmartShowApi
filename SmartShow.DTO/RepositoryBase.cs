using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartShow.DTO
{
    public abstract class RepositoryBase<T> where T : class, new()
    {
        DataContext context;
        readonly IDbSet<T> dbSet;
        public RepositoryBase(IDataBaseFactory factory)
        {
            this.DataBaseFactory = factory;
            dbSet = DataContext.Set<T>();
        }

        protected IDataBaseFactory DataBaseFactory
        {
            get;
            private set;
        }
        public DataContext DataContext
        {
            get
            {
                if (context == null)
                    context = DataBaseFactory.GetInstance();
                if (context.Database.Connection.State != System.Data.ConnectionState.Open)
                    context.Database.Connection.Open();
                return context;
            }
        }

        public T Add(T entity)
        {
            dbSet.Add(entity);
            return entity;
        }

        public void Delete(T Entity)
        {
            dbSet.Remove(Entity);
        }

        public void Update(T Entity)
        {
            dbSet.Attach(Entity);
            context.Entry(Entity).State = EntityState.Modified;

        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }
        public T GetById(int id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).ToList();

        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }

    public interface IRepositoryBase<T> where T : class
    {
        T Add(T Entity);
        void Update(T Entity);
        void Delete(T Entity);
        T GetById(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetMany(Expression<Func<T,bool>> where);
        void SaveChanges();
    }
}
