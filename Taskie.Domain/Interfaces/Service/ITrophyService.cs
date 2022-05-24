using System.Collections.Generic;
using System.Threading.Tasks;
using Taskie.Domain.Dto.Trophy;

namespace Taskie.Domain.Interfaces.Service
{
    public interface ITrophyService
    {
        Task<TrophyDto> GetById(int idTrophy);
        Task<IEnumerable<TrophyDto>> GetAll();
        Task<IEnumerable<TrophyDto>> GetAllObtainedByUser(string userId);
        Task<IEnumerable<TrophyDto>> GetAllNotObtainedByUser(string userId);
        Task<TrophyDto> CrateTrophy(TrophyCreateDto trophyCreate);
        Task<TrophyDto> UpdateTrophy(TrophyCreateDto trophyUpdate);
        Task<bool> DeleteTrophy(int idTrophyr);
    }
}
