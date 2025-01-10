using System.Net;
using MagicVilla_Api_Udemy.Models;
using MagicVilla_Api_Udemy.Models.DTO;
using MagicVilla_Api_Udemy.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla_Api_Udemy.Controllers
{
    [Route("api/userAuth")]
    [ApiController]
    public class UsersController : ControllerBase // Use ControllerBase for API controllers
    {
        private readonly IUserRepository _userRepository;
        protected APIResponse _response;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _response = new APIResponse(); // Initialize response object
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO model)
        {
            if (model == null || string.IsNullOrEmpty(model.Name) || string.IsNullOrEmpty(model.Password))
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Success = false;
                _response.ErrorMessage.Add("Username and password are required.");
                return BadRequest(_response);
            }

            if (string.IsNullOrEmpty(model.Name) || string.IsNullOrEmpty(model.Password))
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Success = false;
                _response.ErrorMessage.Add("Username and password are required.");
                return BadRequest(_response);
            }

            var loginResp = await _userRepository.Login(model);
            if (loginResp == null || loginResp.User == null || string.IsNullOrEmpty(loginResp.Token))
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Success = false;
                _response.ErrorMessage.Add("User or password is incorrect.");
                return BadRequest(_response);
            }

            _response.StatusCode = HttpStatusCode.OK;
            _response.Success = true;
            _response.Result = loginResp; // Return the login response
            return Ok(_response);
        }

        [HttpPost("registration")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDTO model)
        {
            if (model == null || string.IsNullOrEmpty(model.Name) || string.IsNullOrEmpty(model.Password))
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Success = false;
                _response.ErrorMessage.Add("Username and password are required.");
                return BadRequest(_response);
            }

            bool IsUserNameIsUnique = _userRepository.IsUniqueUser(model.Name);
            if (!IsUserNameIsUnique)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Success = false;
                _response.ErrorMessage.Add("User already exists!");
                return BadRequest(_response);
            }

            var user = await _userRepository.Register(model);
            if (user == null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Success = false;
                _response.ErrorMessage.Add("Error while registration!");
                return BadRequest(_response);
            }

            _response.StatusCode = HttpStatusCode.OK;
            _response.Success = true;
            return Ok(_response);
        }
    }
}
