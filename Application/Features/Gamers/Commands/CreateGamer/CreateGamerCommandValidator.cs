using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Gamers.Commands.CreateGamer
{
    public class CreateGamerCommandValidator : AbstractValidator<CreateGamerCommand>
    {
        public CreateGamerCommandValidator()
        {
            RuleFor(g=>g.LeagueId).NotNull();
            RuleFor(g=>g.Score).NotNull();
            RuleFor(g=>g.Username).NotEmpty();
            RuleFor(g=>g.League).NotEmpty();
            RuleFor(g => g.LeagueId).LessThanOrEqualTo(2);
            RuleFor(g => g.LeagueId).GreaterThanOrEqualTo(0);
            
        }
    }
}
