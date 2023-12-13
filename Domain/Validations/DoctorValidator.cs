using System.Data;
using Domain.Entities;
using FluentValidation;
using Shared;

namespace Domain.Validations;

public class DoctorValidator : AbstractValidator<Doctor>
{
    public DoctorValidator()
    {
        RuleFor(x => x.Name).MaximumLength(50);
        RuleFor(x => x.Document).SetValidator(new DocumentValidator());
        RuleFor(x => x.CRM).SetValidator(new CRMValidator());
    }
}