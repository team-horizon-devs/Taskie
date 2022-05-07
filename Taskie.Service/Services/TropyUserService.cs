using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskie.Domain.Dto.TrophyUser;
using Taskie.Domain.Entities;
using Taskie.Domain.Interfaces.Repository;
using Taskie.Domain.Interfaces.Service;

namespace Taskie.Service.Services
{
    public class TrophyUserService : ITrophyUserService
    {
        private readonly ITrophyUserRepository _trophyUserRepository;
        private readonly IMapper _mapper;

        public TrophyUserService(ITrophyUserRepository trophyUserRepository, IMapper mapper)
        {
            _trophyUserRepository = trophyUserRepository;
            _mapper = mapper;
        }
        public async Task<TrophyUserEntity> CreateTrophyUser(TrophyUserCreateDto trophyUserCreate)
        {
            var trophyUser = _mapper.Map<TrophyUserEntity>(trophyUserCreate);
            var result = await _trophyUserRepository.CreateAsync(trophyUser);

            if (result != null) return result;
            

            throw new InvalidOperationException("Ocorreu um erro ao comprar o troféu!");
        }
    }
}
