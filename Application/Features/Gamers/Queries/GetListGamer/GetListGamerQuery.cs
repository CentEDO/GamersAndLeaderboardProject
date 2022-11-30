using Application.Features.Gamers.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Gamers.Queries.GetListGamer
{
    public class GetListGamerQuery : IRequest<GamerListModel>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListGamerQueryHandler : IRequestHandler<GetListGamerQuery, GamerListModel>
        {
            private readonly IGamerRepository _gamerRepository;
            private readonly IMapper _mapper;


            public GetListGamerQueryHandler(IGamerRepository gamerRepository, IMapper mapper)
            {
                _gamerRepository = gamerRepository;
                _mapper = mapper;
            }


            public async Task<GamerListModel> Handle(GetListGamerQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Gamer> gamers = await _gamerRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);


                GamerListModel mappedGamersListModel = _mapper.Map<GamerListModel>(gamers);
                return mappedGamersListModel;
            }
        }
    }
}
