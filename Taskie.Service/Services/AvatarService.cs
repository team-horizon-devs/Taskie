using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taskie.Domain.Dto.Avatar;
using Taskie.Domain.Entities;
using Taskie.Domain.Interfaces.Repository;
using Taskie.Domain.Interfaces.Service;

namespace Taskie.Service.Services
{
    public class AvatarService : IAvatarService
    {
        private readonly IAvatarRepository _avatarRepository;
        private readonly IMapper _mapper;

        public AvatarService(IAvatarRepository avatarRepository, IMapper mapper)
        {
            _avatarRepository = avatarRepository;
            _mapper = mapper;
        }

        public async Task<AvatarDto> GetById(int idAvatar)
        {
            var avatar = await _avatarRepository.GetIdAsync(idAvatar);

            return _mapper.Map<AvatarDto>(avatar);
        }

        public async Task<IEnumerable<AvatarDto>> GetAll()
        {
            var avatar = await _avatarRepository.GetAllAsync();

            return _mapper.Map<List<AvatarDto>>(avatar);
        }

        public async Task<AvatarDto> CrateAvatar(AvatarCreateDto avatarCreate)
        {
            var avatar = _mapper.Map<AvatarEntity>(avatarCreate);
            var created = await _avatarRepository.CreateAsync(avatar);

            return _mapper.Map<AvatarDto>(created);

        }

        public async Task<AvatarDto> UpdateAvatar(AvatarCreateDto avatarUpdate)
        {
            var avatar = _mapper.Map<AvatarEntity>(avatarUpdate);
            var updated = await _avatarRepository.UpdateAsync(avatar);

            return _mapper.Map<AvatarDto>(updated);
        }

        public async Task<bool> RemoveAvatar(int idAvatart)
        {
            var result = await _avatarRepository.DeleteAsync(idAvatart);

            return result;
        }


    }
}
