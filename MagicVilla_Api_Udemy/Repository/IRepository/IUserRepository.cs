using MagicVilla_Api_Udemy.Models;
using MagicVilla_Api_Udemy.Models.DTO;

namespace MagicVilla_Api_Udemy.Repository.IRepository
{
    public interface IUserRepository
    {
        bool IsUniqueUser(string username);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDto);

        Task<LocalUser> Register(RegistrationRequestDTO registrationRequestDTO);
    }
}
