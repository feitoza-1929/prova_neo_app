using Domain.Entities;
using Domain.Entities.ValueObjects;
using Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.ModelsConfiguration;

public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        builder.HasData
        (
            new Appointment()
            {
                Id = Guid.Parse("97abe0f0-c741-4968-a50b-fa6dc84bde69"),
                Value = 50,
                State = AppointmentStates.SCHEDULED,
                ScheduledAt = DateTime.Now.AddDays(55),
                CreatedAt = DateTime.Now,
                DoctorId = Guid.Parse("b7cc578f-c53c-4187-a5d6-558edee55766"),
                PatientId = Guid.Parse("6fb754b6-443c-4c50-823f-5d4d54fbbb58"),
            }
        );
    }
}