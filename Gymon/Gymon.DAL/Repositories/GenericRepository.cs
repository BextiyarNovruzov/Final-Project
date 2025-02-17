using Gymon.Core.Entities;
using Gymon.Core.Enums;
using Gymon.Core.Repostitories;
using Gymon.DAL.Context;
using Gymon.DAL.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
namespace Gymon.DAL.Repositories
{


    public class GenericRepository<T>(GymonDbContext _context) : IGenericRepository<T> where T : BaseEntity, new()
    {
        protected DbSet<T> Table => _context.Set<T>();

        public async Task AddAsync(T entity)
        {
            await Table.AddAsync(entity);
        }
        public IQueryable<T> GetAll()
            => Table.AsQueryable();
        public async Task<T?> GetByIdAsync(int id)
            => await Table.FindAsync(id);

        public IQueryable<T> GetWhere(Func<T, bool> expression)
            => Table.Where(expression).AsQueryable();
        public async Task<bool> IsExistAsync(int id)
            => await Table.AnyAsync(t => t.Id == id);

        public void Delete(T entity)
        {
            Table.Remove(entity);
        }

        public async Task<bool> DeleteAsync(int? id)
        {
            int result = await Table.Where(T => T.Id == id).ExecuteDeleteAsync();
            return result > 0;
        }

        public async Task<int> SaveAsync()
            => await _context.SaveChangesAsync();
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(T entity)
        {
            Table.Update(entity);
        }

        public async Task<T> GetFirstAsync(Func<T, bool> expression)
        {
            return Table.Where(expression).FirstOrDefault();
        }

        public bool ValidateUserCredentials(string username, string password)
        {
          var user = GetByUsername(username);
            if (user != null) return false;
            return HashHelper.VerifyHashedPassword(user.PasswordHash,password); 
        }

        public User GetByUsername(string username)
        {
           return _context.Users.SingleOrDefault(x => x.Username == username);
        }

        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await Table.Where(predicate).ToListAsync();
        }
    }   
}