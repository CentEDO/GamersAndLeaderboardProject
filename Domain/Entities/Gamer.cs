using Core.Persistence.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Gamer:Entity
    {
        public string Username { get; set; }
        public string League { get; set; }
        public int Score { get; set; }
        public int LeagueId { get; set; }//For simplicity, I did not create League entity. LeagueId=0(bronze),LeagueId=1(silver),LeagueId=2(gold)

    }
}
