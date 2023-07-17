using Bank.Domain.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Persistence.Mappings.EFCore
{
    public class CustomerMapping : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("CUSTOMER");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .HasColumnType("nvarchar(20)")
                .HasColumnName("ID");

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("nvarchar(20)")
                .HasColumnName("NAME");

            builder.Property(x => x.Surname)
                .IsRequired()
                .HasColumnType("nvarchar(20)")
                .HasColumnName("SURNAME");

            builder.Property(x => x.Address)
                .IsRequired()
                .HasColumnType("nvarchar(100)")
                .HasColumnName("ADDRESS");

            builder.Property(x => x.IdentityNumber)
                .IsRequired()
                .HasColumnType("nvarchar(20)")
                .HasColumnName("IDENTITY_NUMBER");

            builder.Property(x => x.BirtDate)
                .IsRequired()
                .HasColumnName("BIRTHDATE");
            //Birden fazla hesap bir kişiye ait olabilir.
            builder.HasMany(x => x.Accounts)
                .WithOne(x => x.Customer);
        }
    }
}
