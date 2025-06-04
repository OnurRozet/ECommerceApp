using System.Linq.Expressions;
using IdentityService.Domain.entities;

namespace IdentityService.Application.Interfaces;

public interface IUserRepository
{
    IQueryable<User> GetAll(params Expression<Func<User, object>>[] includes);
    IQueryable<User> Where(Expression<Func<User, bool>> predicate);
    Task<User> GetByIdAsync(int id);
    Task<User> GetByEmailAsync(string email);
    Task AddAsync(User user);
    Task UpdateAsync(User user);
    Task DeleteAsync(User user);
}