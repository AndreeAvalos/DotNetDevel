using DotNetDevel.Controllers.Base;
using DotNetDevel.Models.Enums;
using DotNetDevel.Models.Response.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetDevel.Controllers;
[Route("api/user")]//padre
[ApiController]
public class UserController:BaseController
{

    [HttpGet("login")]
    public async Task<IActionResult> Login()
    {
        return GetResponse(new ResponseSuccess<string>(200, "HOLA MUNDO"));
    }
    
}