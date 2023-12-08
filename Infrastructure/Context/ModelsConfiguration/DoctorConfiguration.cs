using Domain.Entities;
using Domain.Entities.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.ModelsConfiguration;

public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.HasData
        (
            new Doctor()
            {
                Id = Guid.Parse("b7cc578f-c53c-4187-a5d6-558edee55766"),
                CRM = new CRM()
                {
                    UF = "SP",
                    Number = 123456
                },
                Name = "Casper Darling",
                Document = new Domain.Entities.ValueObjects.Document()
                {
                    CPF = "256.012.970-10",
                    RG = "360713221"
                }
            }
        );
    }
}