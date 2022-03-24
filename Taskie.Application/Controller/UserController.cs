using Taskie.Domain.Interfaces.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Taskie.Domain.Dto.User;
using System.Net;
using System;

namespace Taskie.Application.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;


        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            try
            { 
                var user = await _userService.GetById(id);

                if(user != null)return Ok(user);

                return NotFound("Usuário não encontrado");
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet("username/{userName}")]
        public async Task<IActionResult> GetUserByUserName(string userName)
        {
            try
            { 
                var user = await _userService.GetByUserName(userName);

                if (user != null) return Ok(user);

                return NotFound("Usuário não encontrado");
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet("activate")]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            try
            { 
                UserDto userVerification = await _userService.GetById(userId);
                if (userVerification.EmailConfirmed) return Ok("Seu email já foi confirmado, pode usar a vontade :D");

                UserDto user = await _userService.ConfirmEmail(userId, token);

                if (user != null) return Ok(user);
 
                return BadRequest();
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserCreateDto userDto)
        {
            try
            {
                var user = await _userService.GetByUserName(userDto.UserName);

                if(user == null)
                {

                    var createdUser = await _userService.CreateUser(userDto);

                    if(createdUser != null)
                    {

                        string confirmationToken = await _userService.GenerateConfirmedToken(createdUser.Id);

                        string confirmationLink = Url.Action("ConfirmEmail",
                          "user", new
                          {
                              userid = createdUser.Id,
                              token = confirmationToken
                          },
                           protocol: HttpContext.Request.Scheme);

                        _userService.SendEmailConfirmed(createdUser, confirmationLink);

                        return Created($"Usuário cadastrado com sucesso", createdUser);
                    }
                }

                return Ok($"Usuário {user.UserName} já existe");
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"ERRO {e.Message}");
            }
        }
    }
}
