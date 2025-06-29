using DotacionBack.Application.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotacionBack.Application.Validators
{
    public class MunicipioDtoValidator : AbstractValidator<MunicipioDto>
    {
        public MunicipioDtoValidator()
        {
            RuleFor(x => x.NombreMunicipio).NotEmpty();
            RuleFor(x => x.LatitudMunicipio).NotEmpty();
            RuleFor(x => x.LongitudMunicipio).NotEmpty();
        }
    }

}
