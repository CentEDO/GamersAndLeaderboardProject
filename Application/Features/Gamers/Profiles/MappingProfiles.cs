using Application.Features.Gamers.Commands.CreateGamer;
using Application.Features.Gamers.Commands.DeleteGamer;
using Application.Features.Gamers.Commands.UpdateGamer;
using Application.Features.Gamers.Dtos;
using Application.Features.Gamers.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Gamers.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Gamer, CreatedGamerDto>().ReverseMap();
            CreateMap<Gamer, DeletedGamerDto>().ReverseMap();
            CreateMap<Gamer, UpdatedGamerDto>().ReverseMap();
            CreateMap<Gamer, UpdateGamerCommand>().ReverseMap();
            CreateMap<Gamer, CreateGamerCommand>().ReverseMap();
            CreateMap<Gamer, DeleteGamerCommand>().ReverseMap();
            CreateMap<IPaginate<Gamer>, GamerListModel>().ReverseMap();
            CreateMap<Gamer, GamerListDto>().ReverseMap();
        }
    }
}
