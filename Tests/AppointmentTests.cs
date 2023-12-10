using Domain.Entities;
using Domain.Shared;

namespace Tests;

public class AppointmentTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    [TestCase(AppointmentStates.SCHEDULED, AppointmentStates.CREATED)]
    [TestCase(AppointmentStates.RESCHEDULED, AppointmentStates.SCHEDULED)]
    [TestCase(AppointmentStates.CANCELED, AppointmentStates.RESCHEDULED)]
    [TestCase(AppointmentStates.DONE, AppointmentStates.CANCELED)]
    public void IsValidState_ChangeToPreviousState_ShouldBeFalse(AppointmentStates actualState, AppointmentStates previousState)
    {
        // ARRANGE
        var appointment = new Appointment
        {
            State = actualState
        };

        // ACT
        var actual = appointment.IsValidState(previousState);

        // ASSERT
        Assert.IsFalse(actual);
    }

    [Test]
    public void IsValidState_ChangeFromCanceledStateToDoneState_ShouldBeFalse()
    {
        // ARRANGE
        var appointment = new Appointment
        {
            State = AppointmentStates.CANCELED
        };

        // ACT
        var actual = appointment.IsValidState(AppointmentStates.DONE);

        // ASSERT
        Assert.IsFalse(actual);
    }

    [Test]
    public void IsValidDate_DateLowerThanDateNow_ShouldBeFalse()
    {
        // ARRANGE
        var appointment = new Appointment();
        var invalidDate = DateTime.MinValue;

        // ACT
        var actual = appointment.IsValidDate(invalidDate);

        // ASSERT
        Assert.IsFalse(actual);
    }
}