using System.Collections.Generic;
using System.Threading.Tasks;
using Taskie.Domain.Dto.Trophy;

namespace Taskie.Domain.Interfaces.Service
{
    public interface ITrophyService
    {
        Task<TrophyDto> GetById(int idTrophy);
        Task<IEnumerable<TrophyDto>> GetAll();
        Task<TrophyDto> CrateTrophy(TrophyCreateDto trophyCreate);
        Task<TrophyDto> UpdateTrophy(TrophyCreateDto trophyUpdate);
        Task<bool> RemoveTrophy(int idTrophyr);
    }
}
