using System.Linq.Expressions;

namespace Repositories.Contracts
{
    public interface IRepositoryBase<T>{
        IQueryable<T> FindAll(bool trackChanges);

        T? FindByCondition(Expression<Func<T, bool>> expresiion, bool trackChanges);

        void Create(T enitity);

        void Remove(T entity);
    }
}