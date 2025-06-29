using FluentValidation;
using DotacionBack.Application.DTOs;

public class InstitucionDtoValidator : AbstractValidator<InstitucionDto>
{
    public InstitucionDtoValidator()
    {
        RuleFor(x => x.NombreInstitucion).NotEmpty();
        RuleFor(x => x.CalendarioInstitucion).NotEmpty();
        RuleFor(x => x.CodigodaneInstitucion).NotEmpty();
        RuleFor(x => x.FkIdMunicipio).GreaterThan(0);
    }
}
