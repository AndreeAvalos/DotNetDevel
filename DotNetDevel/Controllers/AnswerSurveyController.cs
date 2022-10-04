using DotNetDevel.Controllers.Base;
using DotNetDevel.Entities;
using DotNetDevel.Models.Request;
using DotNetDevel.Models.Response.Models;
using DotNetDevel.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotNetDevel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerSurveyController: BaseController
    {

        private readonly IService<AnswerSurveyEntity> _answerSurveyEntityService;

        public AnswerSurveyController(IService<AnswerSurveyEntity> answerSurveyEntityService)
        {
            _answerSurveyEntityService = answerSurveyEntityService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(AnswerSurveyRequest surveyRequest)
        {
            ResponseSuccess<AnswerSurveyEntity> response = await _answerSurveyEntityService.Post(surveyRequest);
            return GetResponse(response);
        }
    }
}
