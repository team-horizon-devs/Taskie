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
using Taskie.Domain.Dto.TrophyUser;

namespace Taskie.Service.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly SignInManager<UserEntity> _signInManager;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly EmailSettings _mailSettings;
        private readonly ITrophyRepository _trophyRepository;
        private readonly ITrophyUserRepository _trophyUserRepository;


        public UserService(UserManager<UserEntity> userManager, IMapper mapper,
            SignInManager<UserEntity> signInManager, IUserRepository userRepository, 
            EmailSettings emailSettings, ITrophyUserRepository trophyUserRepository, ITrophyRepository trophyRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userRepository = userRepository;
            _mailSettings = emailSettings;
            _mapper = mapper;
            _trophyRepository = trophyRepository;
            _trophyUserRepository = trophyUserRepository;
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

        public async Task<bool> ConfirmEmail(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var result = await _userManager.ConfirmEmailAsync(user, token);

            if (result.Succeeded) return true;

            else return false;
        }

        public async Task<bool> DisabledUser(string userId)
        {
            bool result = await _userRepository.DisableUserAsync(userId);

            return result;
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

        public async Task<bool> UpdateAvatar(string userId, int avatarId)
        {
            bool result = await _userRepository.UpdateAvatarAsync(userId, avatarId);

            return result;
        }

        public async Task<IdentityResult> UpdateUser(UserUpdateDto userUpdateDto)
        {
            UserEntity user = await _userRepository.GetUserByIdAsync(userUpdateDto.Id);

            user.Name = userUpdateDto.Name;
            user.PhoneNumber = userUpdateDto.PhoneNumber;

            var result = await _userManager.UpdateAsync(user);

            return result;

        }

        public async Task<string> GenerateConfirmedToken(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            string confirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            return confirmationToken;
        }

        public async Task<bool> ChangePassword(UserUpdatePassword userUpdatePassword)
        {
            
            UserEntity user = await _userRepository.GetUserByIdAsync(userUpdatePassword.Id);

            var result = await _signInManager.CheckPasswordSignInAsync(user, userUpdatePassword.Password, false);

            if(result.Succeeded)
            {
                var resultUpdate = await _userManager.ChangePasswordAsync(user,
                                                                        userUpdatePassword.Password,
                                                                        userUpdatePassword.NewPassword);
                if (resultUpdate.Succeeded) return true;
            }

            return false;
        }

        public async Task<bool> BuyTrophies(TrophyUserCreateDto trophyUserCreate)
        {
            var user = await _userRepository.GetUserByIdAsync(trophyUserCreate.UserId);
            var trophy = await _trophyRepository.GetIdAsync(trophyUserCreate.TrophyId);

            if (user.Point >= trophy.PricePoints)
            {
                var trophyUser = _mapper.Map<TrophyUserEntity>(trophyUserCreate);

                await _trophyUserRepository.CreateAsync(trophyUser);

                user.Point -= trophy.PricePoints;

                await _userManager.UpdateAsync(user);


                return true;
            }

            return false;
        }
    }
}
