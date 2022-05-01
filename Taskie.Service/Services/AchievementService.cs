using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taskie.Domain.Dto.Achievement;
using Taskie.Domain.Entities;
using Taskie.Domain.Interfaces.Repository;
using Taskie.Domain.Interfaces.Service;

namespace Taskie.Service.Services
{
    public class AchievementService : IAchievementService
    {
        private readonly IAchievementRepository _achievementRepository;
        private readonly IMapper _mapper;   

        public AchievementService(IAchievementRepository achievementRepository, IMapper mapper)
        {
            _achievementRepository = achievementRepository;
            _mapper = mapper;
        }

        public async Task<AchievementDto> GetById(int id)
        {
            var achievment = await _achievementRepository.GetIdAsync(id);

            return _mapper.Map<AchievementDto>(achievment);
        }

        public async Task<IEnumerable<AchievementDto>> GetAll()
        {
            var achievments = await _achievementRepository.GetAllAsync();

            return _mapper.Map<List<AchievementDto>>(achievments);
        }

        public async Task<AchievementDto> CrateAchievement(AchievementCreateDto achievementCreate)
        {
            var achievement = _mapper.Map<AchievementEntity>(achievementCreate);

            var created = await _achievementRepository.CreateAsync(achievement);

            return _mapper.Map<AchievementDto>(created);
        }

        public async Task<AchievementDto> UpdateAchievement(AchievementUpdateDto achieventUpdate)
        {
            var achievement = _mapper.Map<AchievementEntity>(achieventUpdate);
            var updated = await _achievementRepository.UpdateAsync(achievement);

            return _mapper.Map<AchievementDto>(updated);
        }

        public async Task<bool> RemoveAchievement(int idAchievement)
        {
            bool result = await _achievementRepository.DeleteAsync(idAchievement);
            
            return result;
        }
    }
}
