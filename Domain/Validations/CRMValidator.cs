using DocumentValidator;
using Domain.Entities;
using Domain.Entities.ValueObjects;
using FluentValidation;

namespace Domain.Validations;

public class CRMValidator : AbstractValidator<CRM>
{
    public CRMValidator()
    {
        RuleFor(x => x.UF)
            .Must((uf) => uf.Length.Equals(2))
            .WithMessage("{PropertyName} is invalid");

        RuleFor(x => x.Number)
            .Must((number) => number.ToString().Length.Equals(6))
            .WithMessage("{PropertyName} should be 6 digits long");
    }
}