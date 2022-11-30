using Application.Features.Gamers.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Gamers.Queries.GetListGamerByDynamic
{
    public class GetListGamerByDynamicQuery : IRequest<GamerListModel>
    {
        public PageRequest PageRequest { get; set; }
        public Dynamic Dynamic { get; set; }
        public class GetListGamerByDynamicQueryHandler : IRequestHandler<GetListGamerByDynamicQuery, GamerListModel>
        {
            private readonly IGamerRepository _gamerRepository;
            private readonly IMapper _mapper;


            public GetListGamerByDynamicQueryHandler(IGamerRepository gamerRepository, IMapper mapper)
            {
                _gamerRepository = gamerRepository;
                _mapper = mapper;
            }


            public async Task<GamerListModel> Handle(GetListGamerByDynamicQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Gamer> gamers = await _gamerRepository.GetListByDynamicAsync(request.Dynamic,
                    index: request.PageRequest.Page, size: request.PageRequest.PageSize);


                GamerListModel mappedGamersListModel = _mapper.Map<GamerListModel>(gamers);
                return mappedGamersListModel;
            }
        }
    }
}
