using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DotNetDevel.Entities;
using DotNetDevel.Middlewares.Exceptions;
using DotNetDevel.Models.Enums;
using DotNetDevel.Models.Request;
using DotNetDevel.Models.Response.Interface;
using DotNetDevel.Models.Response.Models;
using DotNetDevel.Repositories.Interface;
using DotNetDevel.Services.Interface;
using DotNetDevel.Settings;
using Microsoft.IdentityModel.Tokens;

namespace DotNetDevel.Services.Implementation
{
    public class LoginSeviceImpl : ILoginService
    {
        private readonly IRepository<UserEntity> _repository;
        private readonly JwtSettings _jwtSettings;
        private readonly IResponse _response;

        public LoginSeviceImpl(IRepository<UserEntity> repository, JwtSettings jwtSettings, IResponse response)
        {
            _repository = repository;
            _jwtSettings = jwtSettings;
            _response = response;
        }

        public async Task<ResponseSuccess<string>> LoginAsync(LoginRequest loginRequest)
        {
            UserEntity? entity = await _repository.GetAsync(loginRequest.Name.ToLower());
            if (entity is null || !entity.Password.Equals(loginRequest.Password)) throw new HttpException(HttpEnums.BadRequest, new() { "Usuario/Contraseña incorrectas" });

            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            SigningCredentials credentials = new(securityKey, SecurityAlgorithms.HmacSha256);
            Claim[] claims = {
                new(ClaimTypes.NameIdentifier,loginRequest.Name),
            };

            JwtSecurityToken jwt = new(_jwtSettings.Issuer,
                _jwtSettings.Audience,
                claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials);

            return _response.GetResponseSuccess(HttpEnums.Ok, new JwtSecurityTokenHandler().WriteToken(jwt));
        }
    }
}
