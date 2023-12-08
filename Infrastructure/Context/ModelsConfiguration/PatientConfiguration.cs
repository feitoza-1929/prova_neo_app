using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.ModelsConfiguration;

public class PatientConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.HasData
        (
            new Patient()
            {
                Id = Guid.Parse("6fb754b6-443c-4c50-823f-5d4d54fbbb58"),
                Name = "Jesse Faden",
                Age = 28,
                Document = new Domain.Entities.ValueObjects.Document()
                {
                    CPF = "256.012.970-10",
                    RG = "360713221"
                }
            }
        );
    }
}