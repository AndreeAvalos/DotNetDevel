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
    public class UserServiceImpl : IService<UserEntity>
    {
        private readonly IRepository<UserEntity> _repository;
        private readonly IMapper _mapper;
        private readonly IResponse _response;

        public UserServiceImpl(IRepository<UserEntity> repository, IMapper mapper, IResponse response)
        {
            _repository = repository;
            _mapper = mapper;
            _response = response;
        }

        public async Task<ResponseSuccess<UserEntity>> Post<TR>(TR entity)
        {
            UserEntity user = _mapper.Map<UserEntity>(entity);
            user = await _repository.SaveAsync(user);
            return _response.GetResponseSuccess(HttpEnums.Created, user);
        }

        public async Task<ResponseSuccess<UserEntity>> Put<TR>(TR entity)
        {
            UserRequest userRequest = (entity as UserRequest)!;

            UserEntity? user = await _repository.GetAsync(userRequest.Name.ToLower());
            if (user is null) throw new DatabaseException(HttpEnums.NotFound, new() { "Dato no encontrado." });
            user.Password = userRequest.Password;
            await _repository.SaveChangesAsync();
            return _response.GetResponseSuccess(HttpEnums.Ok, user);
        }

        public async Task<ResponseSuccess<List<UserEntity>>> All()
        {
            return _response.GetResponseSuccess(HttpEnums.Ok, await _repository.GetAllAsync());
        }

        public async Task<ResponseSuccess<UserEntity>> Get<TR>(TR id)
        {
            UserEntity? user = await _repository.GetAsync(id!.ToString()!.ToLower());
            if (user is null) throw new DatabaseException(HttpEnums.NotFound, new() { "Dato no encontrado." });
            return _response.GetResponseSuccess(HttpEnums.Ok, user);
        }

        public async Task<ResponseSuccess<bool>> Delete<TR>(TR id)
        {
            UserEntity? user = await _repository.GetAsync(id!.ToString()!.ToLower());
            if (user is null) throw new DatabaseException(HttpEnums.NotFound, new() { "Dato no encontrado." });
            await _repository.DeleteAsync(user);
            return _response.GetResponseSuccess(HttpEnums.Ok, true);
        }
    }
}
