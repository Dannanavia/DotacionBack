using DotacionBack.Application.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotacionBack.Application.Validators
{
    public class DotacionDtoValidator : AbstractValidator<DotacionDto>
    {
        public DotacionDtoValidator()
        {
            RuleFor(x => x.CantidadDotacion).GreaterThan(0);
            RuleFor(x => x.FkIdArticulo).GreaterThan(0);
            RuleFor(x => x.FkIdSede).GreaterThan(0);
            RuleFor(x => x.FkIdTipodotacion).GreaterThan(0);
        }
    }
}
