using Gymon.Core.Entities;
namespace Gymon.Core.Repostitories;

public interface IGenericRepository<T> where T : BaseEntity, new()
{
    IQueryable<T> GetAll();
    Task<T?> GetByIdAsync(int id);
    User GetByUsername(string username);
    Task<User?> GetUserByUsernameAsync(string username);
    bool ValidateUserCredentials(string username, string password);
 
    IQueryable<T> GetWhere(Func<T, bool> expression);
    Task<T> GetFirstAsync(Func<T, bool> expression);
    Task<bool> IsExistAsync(int id);
    Task AddAsync(T entity);
    void DeleteAsync(T entity);
    Task<bool> DeleteAsync(int id);
    Task UpdateAsync(T entity);
    Task<int> SaveAsync();

}
