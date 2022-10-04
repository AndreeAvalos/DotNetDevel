using DotNetDevel.Database;
using DotNetDevel.Entities;
using DotNetDevel.Repositories.Interface;
using DotNetDevel.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace DotNetDevel.Repositories.Implementation
{
    public class SurveyRepositoryImpl: IRepository<SurveyEntity>
    {
        private readonly DatabaseContext _databaseContext;

        public SurveyRepositoryImpl(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<SurveyEntity> SaveAsync(SurveyEntity entity)
        {
            await _databaseContext.AddAsync(entity);
            await _databaseContext.SaveChangesAsync();
            return entity;
        }

        public async Task<SurveyEntity?> GetAsync<TR>(TR id)
        {
            SurveyEntity? entity = await _databaseContext.SurveyEntity
                .Include(x => x.FieldSurvey)
                .SingleOrDefaultAsync(x => x.Link.Equals(id));

            return entity;
        }

        public Task<List<SurveyEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(SurveyEntity entity)
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
