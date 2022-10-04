using DotNetDevel.Database;
using DotNetDevel.Entities;
using DotNetDevel.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace DotNetDevel.Repositories.Implementation
{
    public class AnswerSurveyRepositoryImpl: IRepository<AnswerSurveyEntity>
    {
        private readonly DatabaseContext _databaseContext;

        public AnswerSurveyRepositoryImpl(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<AnswerSurveyEntity> SaveAsync(AnswerSurveyEntity entity)
        {
            await _databaseContext.AddAsync(entity);
            await _databaseContext.SaveChangesAsync();
            return entity;
        }

        public Task<AnswerSurveyEntity?> GetAsync<TR>(TR id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<AnswerSurveyEntity>> GetAllAsync()
        {
            return await _databaseContext.AnswerSurveys
                .ToListAsync();
        }

        public async Task DeleteAsync(AnswerSurveyEntity entity)
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
