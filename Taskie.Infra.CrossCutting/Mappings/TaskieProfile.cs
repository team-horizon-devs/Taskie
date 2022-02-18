﻿using AutoMapper;
using Taskie.Domain.Dto.User;
using Taskie.Domain.Dto.Avatar;
using Taskie.Domain.Entities;
using Taskie.Domain.Dto.AchievementUser;
using Taskie.Domain.Dto.Achievement;

namespace Taskie.Infra.CrossCutting.Mappings
{
    public class TaskieProfile : Profile
    {
        public TaskieProfile()
        {
            CreateMap<UserEntity, UserDto>().ReverseMap();
            CreateMap<UserEntity, UserDtoCreate>().ReverseMap();
            CreateMap<AvatarEntity, AvatarDto>().ReverseMap();
            CreateMap<AvatarEntity, AvatarToUserDto>().ReverseMap();
            CreateMap<AchievementUserEntity, AchievementUserToUserDto>().ReverseMap();
            CreateMap<AchievementEntity, AchievementToUserDto>().ReverseMap();

        }
    }
}
