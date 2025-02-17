using Gymon.Core.Entities;
using System.Linq.Expressions;
namespace Gymon.Core.Repostitories;

public interface IGenericRepository<T> where T : BaseEntity, new()
{
    IQueryable<T> GetAll();
    Task<T?> GetByIdAsync(int id);
    User GetByUsername(string username);
    Task<User?> GetUserByUsernameAsync(string username);
    Task<List<T>> GetAllAsync();
    bool ValidateUserCredentials(string username, string password);

    IQueryable<T> GetWhere(Func<T, bool> expression);
    Task<T> GetFirstAsync(Func<T, bool> expression);
    Task<bool> IsExistAsync(int id);
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
    Task AddAsync(T entity);
    void Delete(T entity);
    Task<bool> DeleteAsync(int? id);
    Task UpdateAsync(T entity);
    Task<int> SaveAsync();
    Task SaveChangesAsync();

}
