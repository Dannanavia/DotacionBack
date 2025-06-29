using DotacionBack.Application.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotacionBack.Application.Validators
{

    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(x => x.CorreoUsuario)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.ContraseniaUsuario)
                .NotEmpty()
                .MinimumLength(6);
        }
    }
}
