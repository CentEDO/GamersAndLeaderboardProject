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

namespace Application.Features.Gamers.Commands.DeleteGamer
{
    public class DeleteGamerCommand : IRequest<DeletedGamerDto>
    {
        public int Id { get; set; }
        public class DeleteGamerCommandHandler : IRequestHandler<DeleteGamerCommand, DeletedGamerDto>
        {

            private readonly IGamerRepository _gamerRepository;
            private readonly IMapper _mapper;
            private readonly GamerBusinessRules _gamerBusinessRules;

            public DeleteGamerCommandHandler(IGamerRepository gamerRepository, IMapper mapper, GamerBusinessRules gamerBusinessRules)
            {
                _gamerRepository = gamerRepository;
                _mapper = mapper;
                _gamerBusinessRules = gamerBusinessRules;
            }

            public async Task<DeletedGamerDto> Handle(DeleteGamerCommand request, CancellationToken cancellationToken)
            {
                await _gamerBusinessRules.GamerShouldExistWhenDeletedOrUpdated(request.Id);

                Gamer? gamer = await _gamerRepository.GetAsync(l => l.Id == request.Id);
                Gamer deletedgamer = await _gamerRepository.DeleteAsync(gamer!);
                DeletedGamerDto deletedGamerDto = _mapper.Map<DeletedGamerDto>(deletedgamer);
                return deletedGamerDto;
            }
        }
    }
}
