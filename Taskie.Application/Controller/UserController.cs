﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Taskie.Domain.Dto.User;
using Taskie.Domain.Entities;
using Taskie.Domain.Interfaces.Repository;
using Taskie.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;
using AutoMapper;
using System;
using Taskie.Infra.Data.Context;

namespace Taskie.Application.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly IMapper _mapper;
        private readonly TaskieContext _context;
        private readonly EmailSettings _mailSettings;

        public UserController(UserManager<UserEntity> userManager, IMapper mapper,
            TaskieContext context, EmailSettings emailSettings)
        {
            _userManager = userManager;
            _mapper = mapper;
            _context = context;
            _mailSettings = emailSettings;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(string id)
        {

            var user = await _context.User.Include(u => u.Avatar)
                .Include(u => u.AchievementUsers).ThenInclude(au => au.Achievement).FirstOrDefaultAsync(u => u.Id == id);

            if(user == null)
            {
                return NotFound();
            }
            

            return Ok(_mapper.Map<UserDto>(user));
        }

        [HttpGet("activate")]
        public IActionResult ConfirmEmail(string userid, string token)
        {
            var user = _userManager.FindByIdAsync(userid).Result;
            IdentityResult result = _userManager.ConfirmEmailAsync(user, token).Result;

            if (result.Succeeded)
            {
                return Ok("Success");
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserDtoCreate userDto)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(userDto.UserName);

                if(user == null)
                {
                    user = _mapper.Map<UserEntity>(userDto);

                    var result = await _userManager.CreateAsync(user, userDto.Password);

                    if(result.Succeeded)
                    {
                        
                        string confirmationToken = _userManager.GenerateEmailConfirmationTokenAsync(user).Result;

                        string confirmationLink = Url.Action("ConfirmEmail",
                          "user", new
                          {
                              userid = user.Id,
                              token = confirmationToken
                          },
                           protocol: HttpContext.Request.Scheme);

                        SmtpClient client = new(_mailSettings.Host, _mailSettings.Port);

                        client.UseDefaultCredentials = false;
                        client.Credentials = new NetworkCredential(_mailSettings.Email, _mailSettings.Password);
                        client.EnableSsl = true;

                        client.Send(_mailSettings.Email, user.Email,
                               "Email de confirmaçaõ Taskie!",
                           $"Clique no link para confirmar seu email {confirmationLink}");

                        return Created($"Usuário cadastrado com sucesso", _mapper.Map<UserDto>(user));
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
