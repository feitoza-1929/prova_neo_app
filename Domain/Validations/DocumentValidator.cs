using DocumentValidator;
using Domain.Entities;
using Domain.Entities.ValueObjects;
using FluentValidation;

namespace Domain.Validations;

public class DocumentValidator : AbstractValidator<Document>
{
    public DocumentValidator()
    {
        RuleFor(x => x.CPF)
            .Must(CpfValidation.Validate)
            .WithMessage("{PropertyName} is invalid")
            .NotNull();

        RuleFor(x => x.RG)
            .Must(RGValidation.Validate)
            .WithMessage("{PropertyName} is invalid");
    }
}