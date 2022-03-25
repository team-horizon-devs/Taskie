using Taskie.Domain.Interfaces.Repository;
using Taskie.Domain.Interfaces.Service;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taskie.Domain.Dto.User;
using Taskie.Domain.Entities;
using Taskie.Domain.Models;
using System.Net.Mail;
using AutoMapper;
using System.Net;
using System;

namespace Taskie.Service.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly EmailSettings _mailSettings;

        public UserService(UserManager<UserEntity> userManager, IMapper mapper,
            IUserRepository userRepository, EmailSettings emailSettings)
        {
            _userManager = userManager;
            _mapper = mapper;
            _userRepository = userRepository;
            _mailSettings = emailSettings;
        }

        public async Task<UserDto> GetById(string id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);

            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> GetByUserName(string userName)
        {
            var user = await _userRepository.GetUserByUserNameAsync(userName);

            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> CreateUser(UserCreateDto userCreateDto)
        {
            var user = _mapper.Map<UserEntity>(userCreateDto);
            var result = await _userManager.CreateAsync(user, userCreateDto.Password);

            if (result.Succeeded) return _mapper.Map<UserDto>(user);

            throw new InvalidOperationException("Ocorreu um erro ao criar o usuário!");
        }

        public async Task<UserDto> ConfirmEmail(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var result = await _userManager.ConfirmEmailAsync(user, token);

            if (result.Succeeded) return _mapper.Map<UserDto>(user);

            throw new InvalidOperationException("Ocorreu um erro ao confirmar o Email!");
        }

        public Task<UserEntity> DisabledUser(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var users = await _userRepository.GetAllUserAsync();

            return _mapper.Map<List<UserDto>>(users);
        }

        public void SendEmailConfirmed(UserDto user, string confirmationLink)
        {
            SmtpClient client = new(_mailSettings.Host, _mailSettings.Port);

            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(_mailSettings.Email, _mailSettings.Password);
            client.EnableSsl = true;

            client.Send(_mailSettings.Email, user.Email,
                   "Email de confirmação Taskie!",
               $"Clique no link para confirmar seu email {confirmationLink}");
        }

        public async Task<UserDto> AddPonits(string userId, int points)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            user.Point += points;
            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded) return _mapper.Map<UserDto>(user);

            throw new InvalidOperationException("Ocorreu um erro ao confirmar o Email!");
        }

        public Task<UserEntity> UpdateAvatar(UserUpdateDto user)
        {
            throw new NotImplementedException(); 
        }

        public Task<UserEntity> UpdateUser(UserUpdateDto user)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GenerateConfirmedToken(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            string confirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            return confirmationToken;
        }


    }
}
