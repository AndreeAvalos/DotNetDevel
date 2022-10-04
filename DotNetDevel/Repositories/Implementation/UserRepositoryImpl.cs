using DotNetDevel.Database;
using DotNetDevel.Entities;
using DotNetDevel.Models.Response.Interface;
using DotNetDevel.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace DotNetDevel.Repositories.Implementation
{
    public class UserRepositoryImpl : IRepository<UserEntity>
    {
        private readonly DatabaseContext _databaseContext;

        public UserRepositoryImpl(DatabaseContext context)
        {
            _databaseContext = context;
        }
        public async Task<UserEntity> SaveAsync(UserEntity entity)
        {
            await _databaseContext.AddAsync(entity);
            await _databaseContext.SaveChangesAsync();
            return entity;
        }

        public async Task<UserEntity?> GetAsync<TR>(TR id)
        {
            UserEntity? entity = await _databaseContext.UserEntity
                .Where(entity => entity.Name.ToLower().Equals(id!.ToString()))
                .SingleOrDefaultAsync();
            return entity;
        }

        public async Task<List<UserEntity>> GetAllAsync()
        {
            return await _databaseContext.UserEntity
                .ToListAsync();
        }

        public async Task DeleteAsync(UserEntity entity)
        {
            _databaseContext.Remove(entity);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _databaseContext.SaveChangesAsync();
        }
    }
}
