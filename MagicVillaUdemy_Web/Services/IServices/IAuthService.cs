using MagicVillaUdemy_Web.Models.DTO;

namespace MagicVillaUdemy_Web.Services.IServices
{
    public interface IAuthService
    {
        Task<T> LoginAsync<T> (LoginRequestDTO loginRequestDTO);
        Task<T> RegisterAsync<T>(RegistrationRequestDTO registrationRequestDTO);
    }
}
