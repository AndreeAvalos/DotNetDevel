using DotNetDevel.Controllers.Base;
using DotNetDevel.Entities;
using DotNetDevel.Models.Request;
using DotNetDevel.Models.Response.Models;
using DotNetDevel.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotNetDevel.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UserController:BaseController
{
    private readonly IService<UserEntity> _userService;

    public UserController(IService<UserEntity> userService)
    {
        _userService = userService;
    }


    [HttpPost]
    public async Task<IActionResult> Post(UserRequest userRequest)
    {
        ResponseSuccess<UserEntity> response = await _userService.Post(userRequest);
        return GetResponse(response);
    }

    [HttpGet("{name}")]
    public async Task<IActionResult> Get(string name)
    {
        ResponseSuccess<UserEntity> response = await _userService.Get(name);
        return GetResponse(response);
    }

    [HttpPut]
    public async Task<IActionResult> Put(UserRequest userRequest)
    {
        ResponseSuccess<UserEntity> response = await _userService.Put(userRequest);
        return GetResponse(response);
    }
    [HttpGet]
    public async Task<IActionResult> GetAll(UserRequest userRequest)
    {
        ResponseSuccess<List<UserEntity>> response = await _userService.All();
        return GetResponse(response);
    }

    [HttpDelete("{name}")]
    public async Task<IActionResult> Delete(string name)
    {
        ResponseSuccess<bool> response = await _userService.Delete(name);
        return GetResponse(response);
    }
}