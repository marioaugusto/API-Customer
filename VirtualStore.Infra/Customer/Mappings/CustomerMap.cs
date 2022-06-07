using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VirtualStore.Infra.Customer.Mappings;

public class CustomerMap : IEntityTypeConfiguration<VirtualStore.Domain.Customer.Entities.Customer>
{
    public void Configure(EntityTypeBuilder<VirtualStore.Domain.Customer.Entities.Customer> builder)
    {
        builder.ToTable("Customer");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.CPF)
               .IsRequired()
                .HasColumnType("varchar(11)")
               .HasMaxLength(11);
        builder.HasIndex(c => c.CPF)
               .IsUnique();

        builder.Property(c => c.RG)
               .IsRequired()
                .HasColumnType("varchar(10)")
               .HasMaxLength(10);

        builder.Property(c => c.Name)
               .IsRequired()
               .HasColumnType("varchar(20)")
               .HasMaxLength(20);

        builder.Property(c => c.LastName)
        .IsRequired()
        .HasColumnType("varchar(40)")
        .HasMaxLength(120)
        .HasMaxLength(80);

        builder.Property(c => c.State)
               .IsRequired()
                .HasColumnType("varchar(15)")
               .HasMaxLength(15);

        builder.Property(c => c.City)
                .IsRequired()
                 .HasColumnType("varchar(25)")
                .HasMaxLength(25);

        builder.Property(c => c.Neighborhood)
            .IsRequired()
            .HasMaxLength(25);

        builder.Property(c => c.PublicPlace)
            .IsRequired()
            .HasColumnType("varchar(25)")
            .HasMaxLength(50);

        builder.Property(c => c.DateRegister)
            .IsRequired();

        builder.Property(c => c.BirthDate)
            .IsRequired();

        builder.Property(c => c.CEP)
        .HasColumnType("varchar(8)")
            .HasMaxLength(8);

        builder.Property(c => c.Active)
            .HasMaxLength(1)
            .HasColumnType("bit");

    }
}
