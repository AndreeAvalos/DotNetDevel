using DotNetDevel.Models.Request;
using DotNetDevel.Models.Response.Models;

namespace DotNetDevel.Services.Interface
{
    public interface ILoginService
    {
        public Task<ResponseSuccess<string>> LoginAsync(LoginRequest loginRequest);
    }
}
