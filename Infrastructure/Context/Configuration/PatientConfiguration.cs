using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.Configuration;

public class PatientConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.OwnsOne(x => x.Document, doc =>
        {
            doc.Property(x => x.CPF).HasColumnName("CPF");
            doc.Property(x => x.RG).HasColumnName("RG");
        });
    }
}