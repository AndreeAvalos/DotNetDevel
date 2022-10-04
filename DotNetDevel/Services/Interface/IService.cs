using DotNetDevel.Entities;
using DotNetDevel.Models.Response.Models;

namespace DotNetDevel.Services.Interface
{
    public interface IService<T>
    {
        Task<ResponseSuccess<T>> Post<TR>(TR entity);
        Task<ResponseSuccess<T>> Put<TR>(TR entity);
        Task<ResponseSuccess<List<T>>> All();
        Task<ResponseSuccess<T>> Get<TR>(TR id);
        Task<ResponseSuccess<bool>> Delete<TR>(TR id);
    }
}
