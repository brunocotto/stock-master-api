using StockMaster.Domain.Entities;
using StockMaster.Domain.Repositories.User;
using Microsoft.EntityFrameworkCore;

namespace StockMaster.Infrastructure.DataAccess.Repositories;

internal class UserRepository(StockMasterDbContext dbContext) : IUserReadOnlyRepository, IUserWriteOnlyRepository, IUserUpdateOnlyRepository
{
    private readonly StockMasterDbContext _dbContext = dbContext;

    public async Task Add(User user)
    {
        await _dbContext.Users.AddAsync(user);
    }

    public async Task Delete(User user)
    {
        // CASCADA automático - OnDelete na migration
        var userToRemove = await _dbContext.Users.FindAsync(user.Id);
        _dbContext.Users.Remove(userToRemove!);
    }

    public async Task<bool> ExistActiveUserWithEmail(string email)
    {
        return await _dbContext.Users.AnyAsync(user => user.Email.Equals(email));
    }

    public async Task<User> GetById(long id)
    {
        return await _dbContext.Users.FirstAsync(user => user.Id == id);
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        return await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(user => user.Email.Equals(email));
    }

    public void Update(User user)
    {
        _dbContext.Users.Update(user);
    }
}
