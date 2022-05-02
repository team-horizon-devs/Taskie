using System.Collections.Generic;
using System.Threading.Tasks;
using Taskie.Domain.Dto.Avatar;

namespace Taskie.Domain.Interfaces.Service
{
    public interface IAvatarService
    {
        Task<AvatarDto> GetById(int idAvatar);
        Task<IEnumerable<AvatarDto>> GetAll();
        Task<AvatarDto> CrateAvatar(AvatarCreateDto avatarCreate);
        Task<AvatarDto> UpdateAvatar(AvatarCreateDto avatarUpdate);
        Task<bool> RemoveAvatar(int idAvatart);
    }
}
