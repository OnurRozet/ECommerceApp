

using System.Linq.Expressions;
using IdentityService.Application.Interfaces;
using IdentityService.Domain.entities;
using IdentityService.Infrastructure.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.Infrastructure.Repositories;

public class UserRepository(AppDbContext dbContext, IHttpContextAccessor httpContextAccessor):IUserRepository
{
    private readonly AppDbContext _dbContext = dbContext;
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    
    public int UserId
    {
        get
        {
            var userIdClaim = _httpContextAccessor.HttpContext?.User.FindFirst("UserId");

            // Eğer UserId bulunmazsa bir varsayılan değer döner
            if (userIdClaim == null || string.IsNullOrWhiteSpace(userIdClaim.Value))
            {
                return -1; // Örnek: Varsayılan "SystemUser" ID'si
            }

            return int.Parse(userIdClaim.Value);
        }
    }
    public IQueryable<User> GetAll(params Expression<Func<User, object>>[] includes)
    {
        throw new NotImplementedException();
    }

    public IQueryable<User> Where(Expression<Func<User, bool>> predicate)
    {
       return _dbContext.Set<User>().Where(predicate);
    }

    public async Task<User> GetByIdAsync(int id)
    {
        return await _dbContext.Set<User>().FindAsync(id);
    }

    public async Task<User> GetByEmailAsync(string email)
    {
        return await _dbContext.Set<User>().FirstOrDefaultAsync(x => x.Email == email)!;
    }

    public async Task AddAsync(User user)
    {
        user.CreatedBy = UserId;
        _dbContext.Set<User>().Add(user);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(User user)
    {
        user.UpdatedDate = DateTime.Now;
        user.UpdatedBy = UserId;
        _dbContext.Set<User>().Update(user);
        await _dbContext.SaveChangesAsync();
        
    }

    public async Task DeleteAsync(User user)
    {
        user.DeletedDate = DateTime.Now;
        user.DeletedBy = UserId;
        _dbContext.Set<User>().Remove(user);
        await _dbContext.SaveChangesAsync();
    }
}