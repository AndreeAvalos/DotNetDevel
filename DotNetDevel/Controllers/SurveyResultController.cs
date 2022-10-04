using DotNetDevel.Controllers.Base;
using DotNetDevel.Entities;
using DotNetDevel.Models;
using DotNetDevel.Models.Response.Models;
using DotNetDevel.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetDevel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SurveyResultController : BaseController
    {

        private readonly ISurveyResultService _surveyResultService;

        public SurveyResultController(ISurveyResultService surveyResultService)
        {
            _surveyResultService = surveyResultService;
        }

        [HttpGet("{uuid}")]
        public async Task<IActionResult> Get(string uuid)
        {
            ResponseSuccess<AnswerResponse> response = await _surveyResultService.GetResult(uuid);
            return GetResponse(response);
        }

    }
}
