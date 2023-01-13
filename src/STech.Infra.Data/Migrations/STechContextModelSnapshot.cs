using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using STech.Infra.Data.Context;

namespace STech.Infra.Data.Migrations
{
    [DbContext(typeof(STechContext))]
    partial class STechContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("STech.Domain.Models.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<string>("FirstName")
                   .IsRequired()
                   .HasColumnType("varchar(100)")
                   .HasMaxLength(100);

                    b.Property<string>("LastName")
                      .IsRequired()
                      .HasColumnType("varchar(100)")
                      .HasMaxLength(100);

                    b.Property<DateTime>("BirthDate");


                    b.Property<string>("PhoneNumber")
                      .IsRequired()
                      .HasColumnType("varchar(100)")
                      .HasMaxLength(100);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(11);

                    b.Property<string>("BankAccountNumber")
                      .IsRequired()
                      .HasColumnType("varchar(100)")
                      .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });
        }
    }
}
