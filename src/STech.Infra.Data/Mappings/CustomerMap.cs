using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using STech.Domain.Models;

namespace STech.Infra.Data.Mappings
{    
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.FirstName)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.LastName)
               .HasColumnType("varchar(100)")
               .HasMaxLength(100)
               .IsRequired();

            builder.Property(c => c.PhoneNumber)
               .HasColumnType("varchar(100)")
               .HasMaxLength(100)
               .IsRequired();

            builder.Property(c => c.Email)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.BankAccountNumber)
               .HasColumnType("varchar(100)")
               .HasMaxLength(100)
               .IsRequired();
        }
    }
}
