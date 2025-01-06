using MagicVillaUdemy_Web.Models;

namespace MagicVillaUdemy_Web.Services.IServices
{
    public interface IBaseService
    {
        APIResponse responseModel { get; set; }
        Task<T> SendAsync<T>(APIRequest request);
    }
}
