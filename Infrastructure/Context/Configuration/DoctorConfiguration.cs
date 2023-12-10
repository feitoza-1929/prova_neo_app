using Domain.Entities;
using Domain.Entities.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.Configuration;

public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {

        builder.OwnsOne(x => x.CRM, crm =>
        {
            crm.Property(x => x.Number).HasColumnName("CRM_Number");
            crm.Property(x => x.UF).HasColumnName("CRM_UF");
        });

        builder.OwnsOne(x => x.Document, doc =>
        {
            doc.Property(x => x.CPF).HasColumnName("CPF");
            doc.Property(x => x.RG).HasColumnName("RG");
        });
    }
}