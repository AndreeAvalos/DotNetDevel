using DotNetDevel.Entities;
using DotNetDevel.Models;
using DotNetDevel.Models.Response.Models;

namespace DotNetDevel.Services.Interface
{
    public interface ISurveyResultService
    {
        public Task<ResponseSuccess<AnswerResponse>> GetResult(string uuid);
    }
}
