using Application.Features.Gamers.Dtos;
using Application.Features.Gamers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Gamers.Commands.UpdateGamer
{
    public class UpdateGamerCommand:IRequest<UpdatedGamerDto>
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public int LeagueId { get; set; }
        public string League { get; set; }
        public int Score { get; set; }
        public class UpdateGamerCommandHandler : IRequestHandler<UpdateGamerCommand, UpdatedGamerDto>
        {
            private readonly IGamerRepository _gamerRepository;
            private readonly IMapper _mapper;
            private readonly GamerBusinessRules _gamerBusinessRules;

            public UpdateGamerCommandHandler(IGamerRepository gamerRepository, IMapper mapper, GamerBusinessRules gamerBusinessRules)
            {
                _gamerRepository = gamerRepository;
                _mapper = mapper;
                _gamerBusinessRules = gamerBusinessRules;
            }

            public async Task<UpdatedGamerDto> Handle(UpdateGamerCommand request, CancellationToken cancellationToken)
            {
                Gamer? gamer = await _gamerRepository.GetAsync(l => l.Id == request.Id);
                await _gamerBusinessRules.GamerShouldExistWhenDeletedOrUpdated(gamer.Id);
                await _gamerBusinessRules.LeagueIdAndLeagueShouldBeMatched(request.LeagueId, request.League);
                gamer.Username = request.Username;
                gamer.League= request.League;
                gamer.LeagueId=request.LeagueId;
                gamer.Score = request.Score;
                Gamer updatedGamer = await _gamerRepository.UpdateAsync(gamer);
                UpdatedGamerDto updatedGamerDto = _mapper.Map<UpdatedGamerDto>(updatedGamer);

                return updatedGamerDto;
            }
        }
    }
}
