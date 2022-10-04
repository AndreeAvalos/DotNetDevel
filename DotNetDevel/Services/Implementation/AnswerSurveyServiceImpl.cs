using DotNetDevel.Entities;
using DotNetDevel.Middlewares.Exceptions;
using DotNetDevel.Models.Enums;
using DotNetDevel.Models.Request;
using DotNetDevel.Models.Response.Interface;
using DotNetDevel.Models.Response.Models;
using DotNetDevel.Repositories.Interface;
using DotNetDevel.Services.Interface;

namespace DotNetDevel.Services.Implementation
{
    public class AnswerSurveyServiceImpl : IService<AnswerSurveyEntity>
    {
        private readonly IRepository<AnswerSurveyEntity> _answerSurveyRepository;
        private readonly IRepository<SurveyEntity> _surveyRepository;
        private readonly IResponse _response;

        public AnswerSurveyServiceImpl(IRepository<AnswerSurveyEntity> answerSurveyRepository, IRepository<SurveyEntity> surveyRepository, IResponse response)
        {
            _answerSurveyRepository = answerSurveyRepository;
            _surveyRepository = surveyRepository;
            _response = response;
        }

        public async Task<ResponseSuccess<AnswerSurveyEntity>> Post<TR>(TR entity)
        {
            AnswerSurveyRequest surveyRequest = (entity as AnswerSurveyRequest)!;
            SurveyEntity? surveyEntity = await _surveyRepository.GetAsync(surveyRequest.Link);
            if (surveyEntity is null)
            {
                throw new HttpException(HttpEnums.NotFound, new()
                {
                    "Encuesta no encontrada"
                });
            }

            AnswerSurveyEntity responseEntity = new();
            foreach (AnswerSurveyModel surveyRequestAnswer in surveyRequest.Answers)
            {
                foreach (FieldSurveyEntity fieldSurveyEntity in surveyEntity.FieldSurvey)
                {
                    if (fieldSurveyEntity.Id != surveyRequestAnswer.FieldSurveyId) continue;
                    AnswerSurveyEntity answerSurveyEntity = new()
                    {
                        FieldSurveyId = surveyRequestAnswer.FieldSurveyId,
                        Answer = surveyRequestAnswer.Answer,
                    };
                    responseEntity = await _answerSurveyRepository.SaveAsync(answerSurveyEntity);
                }
            }

            return _response.GetResponseSuccess(HttpEnums.Created, responseEntity);

        }

        public Task<ResponseSuccess<AnswerSurveyEntity>> Put<TR>(TR entity)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseSuccess<List<AnswerSurveyEntity>>> All()
        {
            return _response.GetResponseSuccess(HttpEnums.Ok, await _answerSurveyRepository.GetAllAsync());
        }

        public Task<ResponseSuccess<AnswerSurveyEntity>> Get<TR>(TR id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseSuccess<bool>> Delete<TR>(TR id)
        {
            throw new NotImplementedException();
        }
    }
}
