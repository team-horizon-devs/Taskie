using AutoMapper;
using Taskie.Domain.Dto.User;
using Taskie.Domain.Dto.Avatar;
using Taskie.Domain.Entities;
using Taskie.Domain.Dto.AchievementUser;
using Taskie.Domain.Dto.Achievement;
using Taskie.Domain.Dto.Trophy;
using Taskie.Domain.Dto.TrophyUser;
using Taskie.Domain.Dto.Task;

namespace Taskie.Infra.CrossCutting.Mappings
{
    public class TaskieProfile : Profile
    {
        public TaskieProfile()
        {
            CreateMap<UserEntity, UserDto>().ReverseMap();
            CreateMap<UserEntity, UserCreateDto>().ReverseMap();
            CreateMap<UserEntity, UserUpdateDto>().ReverseMap();

            CreateMap<AvatarEntity, AvatarDto>().ReverseMap();
            CreateMap<AvatarEntity, AvatarToUserDto>().ReverseMap();
            CreateMap<AvatarEntity, AvatarCreateDto>().ReverseMap();
            CreateMap<AvatarEntity, AvatarUpdateDto>().ReverseMap();

            CreateMap<AchievementUserEntity, AchievementUserToUserDto>().ReverseMap();

            CreateMap<AchievementEntity, AchievementToUserDto>().ReverseMap();
            CreateMap<AchievementEntity, AchievementDto>().ReverseMap();
            CreateMap<AchievementEntity, AchievementCreateDto>().ReverseMap();
            CreateMap<AchievementEntity, AchievementUpdateDto>().ReverseMap();

            CreateMap<TrophyUserEntity, TrophyUserToUserDto>().ReverseMap();
            CreateMap<TrophyUserEntity, TrophyUserCreateDto>().ReverseMap();

            CreateMap<TrophyEntity, TrophyDto>().ReverseMap();
            CreateMap<TrophyEntity, TrophyToUserDto>().ReverseMap();
            CreateMap<TrophyEntity, TrophyCreateDto>().ReverseMap();
            CreateMap<TrophyEntity, TrophyUpdateDto>().ReverseMap();

            CreateMap<TrophyEntity, TrophyDto>().ReverseMap();
            CreateMap<TrophyEntity, TrophyToUserDto>().ReverseMap();

            CreateMap<TaskEntity, TaskDto>().ReverseMap();
            CreateMap<TaskEntity, TaskCreateDto>().ReverseMap();
            CreateMap<TaskEntity, TaskUpdateDto>().ReverseMap();
        }
    }
}
