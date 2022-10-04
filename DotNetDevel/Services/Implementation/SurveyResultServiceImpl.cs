using DotNetDevel.Entities;
using DotNetDevel.Middlewares.Exceptions;
using DotNetDevel.Models;
using DotNetDevel.Models.Enums;
using DotNetDevel.Models.Response.Interface;
using DotNetDevel.Models.Response.Models;
using DotNetDevel.Repositories.Interface;
using DotNetDevel.Services.Interface;

namespace DotNetDevel.Services.Implementation
{
    public class SurveyResultServiceImpl : ISurveyResultService
    {
        private readonly IRepository<SurveyEntity> _surveyEntityRepository;
        private readonly IRepository<AnswerSurveyEntity> _answerSurveyEntityRepository;
        private readonly IResponse _response;

        public SurveyResultServiceImpl(IRepository<SurveyEntity> surveyEntityRepository, IRepository<AnswerSurveyEntity> answerSurveyEntityRepository, IResponse response)
        {
            _surveyEntityRepository = surveyEntityRepository;
            _answerSurveyEntityRepository = answerSurveyEntityRepository;
            _response = response;
        }


        public async Task<ResponseSuccess<AnswerResponse>> GetResult(string uuid)
        {
            SurveyEntity? surveyEntity = await _surveyEntityRepository.GetAsync(uuid);
            if (surveyEntity is null)
            {
                throw new HttpException(HttpEnums.NotFound, new()
                {
                    "Encuesta no encontrada"
                });
            }

            List<AnswerSurveyEntity> answerSurveyEntities = await _answerSurveyEntityRepository.GetAllAsync();

            AnswerResponse answerResponse = new()
            {
                Link = uuid,
                Answers = new()
            };

            foreach (FieldSurveyEntity fieldSurveyEntity in surveyEntity.FieldSurvey)
            {
                AnswerModel answerModel = new AnswerModel()
                {
                    Answers = answerSurveyEntities.Where(entity => entity.FieldSurveyId == fieldSurveyEntity.Id)
                        .Select(entity => entity.Answer).ToList(),
                    Question = fieldSurveyEntity.Name
                };
                answerResponse.Answers.Add(answerModel);
            }

            return _response.GetResponseSuccess(HttpEnums.Ok, answerResponse);
        }
    }
}
