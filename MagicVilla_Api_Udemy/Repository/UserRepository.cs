using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MagicVilla_Api_Udemy.Models;
using MagicVilla_Api_Udemy.Models.DTO;
using MagicVilla_Api_Udemy.Repository.IRepository;
using Microsoft.IdentityModel.Tokens;

namespace MagicVilla_Api_Udemy.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;
        private string SecretKey;

        public UserRepository(ApplicationDbContext db, IConfiguration configuration)
        {
            _db = db;
            SecretKey = configuration.GetValue<string>("ApiSetting:Secret");
        }
        public bool IsUniqueUser(string username)
        {
            var User  = _db.LocalUsers.FirstOrDefault(x=>x.Name == username);
            if (User == null)
            {
                return true;
            }
            return false;
        }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDto)
        {
            var user = _db.LocalUsers.FirstOrDefault(u=>u.Name.ToLower() == loginRequestDto.Name.ToLower() && u.Password == loginRequestDto.Password);
            if (user == null) 
            {
                return new LoginResponseDTO()
                {
                    Token = "",
                    User = null,
                };
            }

            // If user found generate JWT token
            var TokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,user.Id.ToString()),
                    new Claim(ClaimTypes.Role,user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(5),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = TokenHandler.CreateToken(tokenDescriptor);
            LoginResponseDTO loginResponseDTO = new ();
            {
                loginResponseDTO.Token = TokenHandler.WriteToken(token);
                loginResponseDTO.User = user;
            }
            return loginResponseDTO;
        }

        public async Task<LocalUser> Register(RegistrationRequestDTO registrationRequestDTO)
        {
            // Additng user info into database.
            LocalUser user = new LocalUser();
            {
                user.Name = registrationRequestDTO.Name;
                user.Email = registrationRequestDTO.Email;
                user.Password = registrationRequestDTO.Password;
                user.Role = registrationRequestDTO.Role;
            }
            _db.LocalUsers.Add(user);
            await _db.SaveChangesAsync();
            user.Password = "";
            return user;
        }
    }
}
