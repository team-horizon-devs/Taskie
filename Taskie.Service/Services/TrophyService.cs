﻿using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taskie.Domain.Dto.Trophy;
using Taskie.Domain.Entities;
using Taskie.Domain.Interfaces.Repository;
using Taskie.Domain.Interfaces.Service;

namespace Taskie.Service.Services
{
    public class TrophyService : ITrophyService
    {
        private readonly ITrophyRepository _trophyRepository;
        private readonly IMapper _mapper;

        public TrophyService(ITrophyRepository trophyRepository, IMapper mapper)
        {
            _trophyRepository = trophyRepository;
            _mapper = mapper;
        }

        public async Task<TrophyDto> GetById(int idTrophy)
        {
            var trophy = await _trophyRepository.GetIdAsync(idTrophy);

            return _mapper.Map<TrophyDto>(trophy);
        }

        public async Task<IEnumerable<TrophyDto>> GetAll()
        {
            var trophy = await _trophyRepository.GetAllAsync();

            return _mapper.Map<List<TrophyDto>>(trophy);
        }

        public async Task<TrophyDto> CrateTrophy(TrophyCreateDto trophyCreate)
        {
            var trophy = _mapper.Map<TrophyEntity>(trophyCreate);
            var created = await _trophyRepository.CreateAsync(trophy);

            return _mapper.Map<TrophyDto>(created);

        }

        public async Task<TrophyDto> UpdateTrophy(TrophyCreateDto trophyUpdate)
        {
            var trophy = _mapper.Map<TrophyEntity>(trophyUpdate);
            var updated = await _trophyRepository.UpdateAsync(trophy);

            return _mapper.Map<TrophyDto>(updated);
        }

        public async Task<bool> RemoveTrophy(int idTrophy)
        {
            var result = await _trophyRepository.DeleteAsync(idTrophy);

            return result;
        }


    }
}