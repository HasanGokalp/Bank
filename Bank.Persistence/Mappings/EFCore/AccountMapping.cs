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
    public class AccountMapping : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("ACCOUNTS");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .HasColumnType("nvarchar(20)")
                .HasColumnName("ID");

            builder.Property(x => x.CreationDate)
                .IsRequired()
                .HasColumnType("nvarchar(20)")
                .HasColumnName("CREATION_DATE");

            builder.Property(x => x.CustomerId)
                .HasColumnType("nvarchar(20)")
                .HasColumnName("CUSTOMER_ID");
            //Bir müşterinin birden fazla hesabı olabilir.
            builder.HasOne(x => x.Customer)
                .WithMany(x => x.Accounts);
        }
    }
}
