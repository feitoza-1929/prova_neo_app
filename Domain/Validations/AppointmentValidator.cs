using Domain.Entities;
using FluentValidation;
using Shared;

namespace Domain.Validations;

public class AppointmentValidator : AbstractValidator<Appointment>
{
    public AppointmentValidator()
    {
        RuleFor(x => x.PatientId).NotNull();
        RuleFor(x => x.DoctorId).NotNull();
        RuleFor(x => x.Value).ExclusiveBetween(1,5000).NotNull();
        RuleFor(x => x.ScheduledAt).GreaterThanOrEqualTo(DateTime.Now).NotNull();
        RuleFor(x => x.State).Must((rootObject, newState, context) => 
        {
            if (rootObject.State > newState)
                return false;

            if (rootObject.State.Equals(AppointmentStates.CANCELED) && newState.Equals(AppointmentStates.DONE))
                return false;

            return true;
        })
        .WithMessage("{PropertyName} value can't be set to a previous state")
        .NotNull();
    }
}