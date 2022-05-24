using Taskie.Domain.Interfaces.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Taskie.Domain.Dto.User;
using System.Net;
using System;
using Taskie.Domain.Dto.TrophyUser;

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

                bool result = await _userService.ConfirmEmail(userId, token);

                if (result) return Ok("Email confirmado com sucesso!");
 
                return BadRequest("Erro ao confirmar email :(");
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

        [HttpPost("changepassword")]
        public async Task<IActionResult> ChangePassword(UserUpdatePassword userUpdatePassword)
        {
            if (userUpdatePassword.Password == userUpdatePassword.NewPassword)
                return BadRequest("Esta já é sua senha atual");

            bool result = await _userService.ChangePassword(userUpdatePassword);

            if(result) return Ok("Senha alterada com sucesso!");

            return BadRequest("Senha atual incorreta");
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateUser(UserUpdateDto userUpdateDto)
        {
            try
            {

                var result = await _userService.UpdateUser(userUpdateDto);

                if (result.Succeeded) return Ok("Usuário editado com sucesso!");

                return BadRequest("Erro ao editar usuário");
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"ERRO {e.Message}");
            }
        }

        [HttpPost("buytrophies")]
        public async Task<IActionResult> BuyTrophies(TrophyUserCreateDto trophyUserCreate)
        {
            try
            {
                var result = await _userService.BuyTrophies(trophyUserCreate);

                if (result != null) return Ok(result);

                return BadRequest();
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status400BadRequest, $"ERRO {e.Message}");
            }
        }

    }
}
