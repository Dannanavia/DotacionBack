using DotacionBack.Application.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotacionBack.Application.Validators
{
    public class SedeDtoValidator : AbstractValidator<SedeDto>
    {
        public SedeDtoValidator()
        {
            RuleFor(x => x.NombreSede).NotEmpty();
            RuleFor(x => x.CodigodaneSede).NotEmpty();
            RuleFor(x => x.DireccionSede).NotEmpty();
            RuleFor(x => x.LatitudSede).NotEmpty();
            RuleFor(x => x.LongitudSede).NotEmpty();
            RuleFor(x => x.ZonaSede).NotEmpty();
            RuleFor(x => x.FkIdInstitucion).GreaterThan(0);
        }
    }

}
