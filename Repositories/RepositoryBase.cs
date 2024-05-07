using System.Linq.Expressions;
using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T>
    where T : class, new()      // instancesi oluşturulabilri class tipinde olcak
    {
        protected readonly RepositoryContext _context;  // kalıtım alanalr contexte erişsin diye

        protected RepositoryBase(RepositoryContext context)
        {
            _context = context;
        }

        public void Create(T enitity)
        {
            _context.Set<T>().Add(enitity);
        }

        public IQueryable<T> FindAll(bool trackChanges)
        {
            return trackChanges
                ? _context.Set<T>()     // değişkenler izlencekse
                : _context.Set<T>().AsNoTracking();     // değilse
        }

        public T? FindByCondition(Expression<Func<T, bool>> expresiion, bool trackChanges)
        {
            return trackChanges 
                ? _context.Set<T>().Where(expresiion).SingleOrDefault()
                : _context.Set<T>().Where(expresiion).AsNoTracking().SingleOrDefault();
        }

        public void Update(T enetity){
            _context.Set<T>().Update(enetity);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
    }
}