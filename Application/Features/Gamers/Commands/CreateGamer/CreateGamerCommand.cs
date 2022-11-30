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

namespace Application.Features.Gamers.Commands.CreateGamer
{
    public class CreateGamerCommand : IRequest<CreatedGamerDto>
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public int Score { get; set; }
        public string League { get; set; }
        public int LeagueId { get; set; }

        public class CreateGamerCommandHandler : IRequestHandler<CreateGamerCommand, CreatedGamerDto>
        {

            private readonly IGamerRepository _gamerRepository;
            private readonly IMapper _mapper;
            private readonly GamerBusinessRules _gamerBusinessRules;

            public CreateGamerCommandHandler(IGamerRepository gamerRepository, IMapper mapper, GamerBusinessRules gamerBusinessRules)
            {
                _gamerRepository = gamerRepository;
                _mapper = mapper;
                _gamerBusinessRules = gamerBusinessRules;
            }

            public async Task<CreatedGamerDto> Handle(CreateGamerCommand request, CancellationToken cancellationToken)
            {
                await _gamerBusinessRules.GamerNameCanNotBeDuplicatedWhenInsertedOrUpdated(request.Username);
                await _gamerBusinessRules.LeagueIdAndLeagueShouldBeMatched(request.LeagueId,request.League);

                Gamer mappedGamer = _mapper.Map<Gamer>(request);
                Gamer createdGamer = await _gamerRepository.AddAsync(mappedGamer);
                CreatedGamerDto createdGamerDto = _mapper.Map<CreatedGamerDto>(createdGamer);
                return createdGamerDto;
            }
        }
    }
}
