using AutoMapper;
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
    public class SurveyServiceImpl : IService<SurveyEntity>
    {
        private readonly IRepository<SurveyEntity> _surveyRepository;
        private readonly IRepository<FieldSurveyEntity> _fieldSurveyRepository;
        private readonly IRepository<AnswerSurveyEntity> _answerSurveyRepository;
        private readonly IResponse _response;
        private readonly IMapper _mapper;

        public SurveyServiceImpl(IRepository<SurveyEntity> surveyRepository, IRepository<FieldSurveyEntity> fieldSurveyRepository, IRepository<AnswerSurveyEntity> answerSurveyRepository, IResponse response, IMapper mapper)
        {
            _surveyRepository = surveyRepository;
            _fieldSurveyRepository = fieldSurveyRepository;
            _answerSurveyRepository = answerSurveyRepository;
            _response = response;
            _mapper = mapper;
        }

        public async Task<ResponseSuccess<SurveyEntity>> Post<TR>(TR entity)
        {
            SurveyRequest surveyRequest = (entity as SurveyRequest)!;
            SurveyEntity surveyEntity = _mapper.Map<SurveyEntity>(surveyRequest);
            surveyEntity.Link = Guid.NewGuid().ToString();
            surveyEntity = await _surveyRepository.SaveAsync(surveyEntity);

            foreach (FieldSurveyRequest fieldSurveyRequest in surveyRequest.Fields)
            {
                FieldSurveyEntity fieldSurveyEntity = _mapper.Map<FieldSurveyEntity>(fieldSurveyRequest);
                fieldSurveyEntity.SurveyId = surveyEntity.Id;

                await _fieldSurveyRepository.SaveAsync(fieldSurveyEntity);
            }

            return _response.GetResponseSuccess(HttpEnums.Created, surveyEntity);
        }

        public async Task<ResponseSuccess<SurveyEntity>> Put<TR>(TR entity)
        {
            SurveyRequest surveyRequest = (entity as SurveyRequest)!;
            if (surveyRequest.Link is null)
            {
                throw new HttpException(HttpEnums.NotFound, new()
                {
                    "Parametro Link faltante"
                });
            }
            SurveyEntity? surveyEntity = await _surveyRepository.GetAsync(surveyRequest.Link);
            if (surveyEntity is null)
            {
                throw new HttpException(HttpEnums.NotFound, new()
                {
                    "Encuesta no encontrada"
                });
            }

            surveyEntity.Description = surveyRequest.Description;
            surveyEntity.Name = surveyRequest.Name;

            foreach (FieldSurveyEntity fieldSurveyEntity in surveyEntity.FieldSurvey)
            {
                await _fieldSurveyRepository.DeleteAsync(fieldSurveyEntity);
            }

            foreach (FieldSurveyRequest fieldSurveyRequest in surveyRequest.Fields)
            {
                FieldSurveyEntity fieldSurveyEntity = _mapper.Map<FieldSurveyEntity>(fieldSurveyRequest);
                fieldSurveyEntity.SurveyId = surveyEntity.Id;

                await _fieldSurveyRepository.SaveAsync(fieldSurveyEntity);
            }

            return _response.GetResponseSuccess(HttpEnums.Ok, surveyEntity);

        }

        public Task<ResponseSuccess<List<SurveyEntity>>> All()
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseSuccess<SurveyEntity>> Get<TR>(TR id)
        {
            if (id is null)
            {
                throw new HttpException(HttpEnums.NotFound, new()
                {
                    "Parametro Link faltante"
                });
            }
            SurveyEntity? surveyEntity = await _surveyRepository.GetAsync(id.ToString());
            if (surveyEntity is null)
            {
                throw new HttpException(HttpEnums.NotFound, new()
                {
                    "Encuesta no encontrada"
                });
            }

            return _response.GetResponseSuccess(HttpEnums.Ok, surveyEntity);
        }

        public async Task<ResponseSuccess<bool>> Delete<TR>(TR id)
        {
            if (id is null)
            {
                throw new HttpException(HttpEnums.NotFound, new()
                {
                    "Parametro Link faltante"
                });
            }
            SurveyEntity? surveyEntity = await _surveyRepository.GetAsync(id.ToString());
            if (surveyEntity is null)
            {
                throw new HttpException(HttpEnums.NotFound, new()
                {
                    "Encuesta no encontrada"
                });
            }
            
            await _surveyRepository.DeleteAsync(surveyEntity);

            return _response.GetResponseSuccess(HttpEnums.Ok, true);
        }
    }
}
