using DotNetDevel.Controllers.Base;
using DotNetDevel.Models.Request;
using DotNetDevel.Models.Response.Models;
using DotNetDevel.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetDevel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : BaseController
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            ResponseSuccess<string> response = await _loginService.LoginAsync(loginRequest);
            return GetResponse(response);
        }
    }
}
