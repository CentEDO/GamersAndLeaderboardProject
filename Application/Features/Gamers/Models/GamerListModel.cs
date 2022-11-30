using Application.Features.Gamers.Dtos;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Gamers.Models
{
    public class GamerListModel:BasePageableModel
    {
        public IList<GamerListDto> Items { get; set; }

    }
}
