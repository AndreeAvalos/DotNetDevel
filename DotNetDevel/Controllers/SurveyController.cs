using DotNetDevel.Controllers.Base;
using DotNetDevel.Entities;
using DotNetDevel.Models.Request;
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
    public class SurveyController : BaseController
    {
        private readonly IService<SurveyEntity> _surveyEntityService;

        public SurveyController(IService<SurveyEntity> surveyEntityService)
        {
            _surveyEntityService = surveyEntityService;
        }


        [HttpPost]
        public async Task<IActionResult> Post(SurveyRequest surveyRequest)
        {
            ResponseSuccess<SurveyEntity> response = await _surveyEntityService.Post(surveyRequest);
            return GetResponse(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(SurveyRequest surveyRequest)
        {
            ResponseSuccess<SurveyEntity> response = await _surveyEntityService.Put(surveyRequest);
            return GetResponse(response);
        }
        [HttpGet("{uuid}")]
        public async Task<IActionResult> Get(string uuid)
        {
            ResponseSuccess<SurveyEntity> response = await _surveyEntityService.Get(uuid);
            return GetResponse(response);
        }

        [HttpDelete("{uuid}")]
        public async Task<IActionResult> Delete(string uuid)
        {
            ResponseSuccess<bool> response = await _surveyEntityService.Delete(uuid);
            return GetResponse(response);
        }
    }
}
