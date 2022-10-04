using DotNetDevel.Database;
using DotNetDevel.Entities;
using DotNetDevel.Repositories.Interface;

namespace DotNetDevel.Repositories.Implementation
{
    public class FieldSurveyRepositoryImpl: IRepository<FieldSurveyEntity>
    {
        private readonly DatabaseContext _databaseContext;

        public FieldSurveyRepositoryImpl(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<FieldSurveyEntity> SaveAsync(FieldSurveyEntity entity)
        {
            await _databaseContext.AddAsync(entity);
            await _databaseContext.SaveChangesAsync();
            return entity;
        }

        public Task<FieldSurveyEntity?> GetAsync<TR>(TR id)
        {
            throw new NotImplementedException();
        }

        public Task<List<FieldSurveyEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(FieldSurveyEntity entity)
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
