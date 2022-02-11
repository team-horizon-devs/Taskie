using AutoMapper;
using Taskie.Domain.Dto;
using Taskie.Domain.Entities;

namespace Taskie.Infra.CrossCutting.Mappings
{
    class TaskieProfile : Profile
    {
        public TaskieProfile()
        {
            CreateMap<UserEntity, UserDto>().ReverseMap();
        }
    }
}
