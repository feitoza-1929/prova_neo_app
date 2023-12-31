using Domain.Entities;
using FluentValidation;
using Shared;

namespace Domain.Validations;

public class PatientValidator : AbstractValidator<Patient>
{
    public PatientValidator()
    {
        RuleFor(x => x.Name).MaximumLength(50);
        RuleFor(x => x.Age).ExclusiveBetween(0,120);
        RuleFor(customer => customer.Document).SetValidator(new DocumentValidator());
    }
}