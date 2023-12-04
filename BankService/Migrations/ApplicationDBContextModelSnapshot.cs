﻿// <auto-generated />
using System;
using APIBankService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APIBankService.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("APIBankService.Models.BankAccount", b =>
                {
                    b.Property<int>("IdAccount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAccount"));

                    b.Property<float>("AccountAmount")
                        .HasColumnType("real");

                    b.Property<int>("AccountNumber")
                        .HasColumnType("int");

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.HasKey("IdAccount");

                    b.ToTable("bankAccount");

                    b.HasData(
                        new
                        {
                            IdAccount = 1,
                            AccountAmount = 1f,
                            AccountNumber = 1,
                            IdUser = 1
                        });
                });

            modelBuilder.Entity("APIBankService.Models.Transferencia", b =>
                {
                    b.Property<int>("IdTransfer")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTransfer"));

                    b.Property<float>("Amount")
                        .HasColumnType("real");

                    b.Property<DateTime>("DateIssue")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdAccountReceiver")
                        .HasColumnType("int");

                    b.Property<int>("IdAccountSender")
                        .HasColumnType("int");

                    b.HasKey("IdTransfer");

                    b.ToTable("transferencia");
                });

            modelBuilder.Entity("APIBankService.Models.User", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUser"));

                    b.Property<string>("DNI")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUser");

                    b.ToTable("user");

                    b.HasData(
                        new
                        {
                            IdUser = 1,
                            DNI = "1",
                            Email = "isaac@gmail.com",
                            Name = "Isaac",
                            Password = "2234334",
                            Phone = "233334",
                            Role = "1"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
