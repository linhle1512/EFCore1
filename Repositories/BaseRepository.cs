using System.Linq.Expressions;
using EFcore.Models;
using Microsoft.EntityFrameworkCore;

namespace EFcore.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity<int>
    {
        private readonly DbSet<T> _dbSet;
        private readonly StudentManagementContext _context;

        public BaseRepository(StudentManagementContext context)
        {
            _dbSet = context.Set<T>();
            _context = context;
        }

        public T Create(T entity)
        {
            return _dbSet.Add(entity).Entity;
        }

        public bool Delete(T entity)
        {
            _dbSet.Remove(entity);

            return true;
        }

        public T? Get(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public T Update(T entity)
        {
            return _dbSet.Update(entity).Entity;
        }
    }
}