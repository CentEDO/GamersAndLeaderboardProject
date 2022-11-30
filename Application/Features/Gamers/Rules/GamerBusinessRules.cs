using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Gamers.Rules
{
    public class GamerBusinessRules
    {
        private readonly IGamerRepository _gamerRepository;

        public GamerBusinessRules(IGamerRepository gamerRepository)
        {
            _gamerRepository = gamerRepository;
        }
        public async Task GamerNameCanNotBeDuplicatedWhenInsertedOrUpdated(string username)
        {
            IPaginate<Gamer> result = await _gamerRepository.GetListAsync(l => l.Username == username);
            if (result.Items.Any()) throw new BusinessException("Username exists!");
        }
        public async Task GamerShouldExistWhenDeletedOrUpdated(int id)
        {
            Gamer? gamer = await _gamerRepository.GetAsync(l => l.Id == id);
            if (gamer == null) throw new BusinessException("Requested gamer does not exists!");
        }
        public async Task LeagueIdAndLeagueShouldBeMatched(int leagueId,string league)
        {
            
            if (leagueId == 2 && league == "gold") ;
            else if (leagueId == 1 && league == "silver") ;
            else if (leagueId == 0 && league == "bronze") ;
            else {
                throw new BusinessException("League Id and League must match ");
            }
        }

    }
    
}
