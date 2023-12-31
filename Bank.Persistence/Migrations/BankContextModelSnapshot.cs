﻿// <auto-generated />
using System;
using Bank.Persistence.Contexts.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bank.Persistence.Migrations
{
    [DbContext(typeof(BankContext))]
    partial class BankContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Bank.Domain.Concrete.Account", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("ID");

                    b.Property<string>("CreationDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("CREATION_DATE");

                    b.Property<string>("CustomerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("CUSTOMER_ID");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("ACCOUNTS", (string)null);
                });

            modelBuilder.Entity("Bank.Domain.Concrete.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("ADDRESS");

                    b.Property<DateTime>("BirtDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("BIRTHDATE");

                    b.Property<string>("FathersName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentityNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("IDENTITY_NUMBER");

                    b.Property<string>("MothersName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("NAME");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("SURNAME");

                    b.HasKey("Id");

                    b.ToTable("CUSTOMER", (string)null);
                });

            modelBuilder.Entity("Bank.Domain.Concrete.Account", b =>
                {
                    b.HasOne("Bank.Domain.Concrete.Customer", "Customer")
                        .WithMany("Accounts")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Bank.Domain.Concrete.Customer", b =>
                {
                    b.Navigation("Accounts");
                });
#pragma warning restore 612, 618
        }
    }
}
