using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Gamers.Dtos
{
    public class UpdatedGamerDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public int Score { get; set; }
        public string League { get; set; }
        public int LeagueId { get; set; }
    }
}
