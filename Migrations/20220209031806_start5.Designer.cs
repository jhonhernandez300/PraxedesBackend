﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PraxedesBackend.Models;

namespace PraxedesBackend.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220209031806_start5")]
    partial class start5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PraxedesBackend.Models.Relative", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("InLaw")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("InLaw");

                    b.Property<int>("RelativeAge")
                        .HasColumnType("int")
                        .HasColumnName("RelativeAge");

                    b.Property<int>("RelativeDocumentNumber")
                        .HasColumnType("int")
                        .HasColumnName("RelativeDocumentNumber");

                    b.Property<string>("RelativeGender")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("RelativeGender");

                    b.Property<string>("RelativeLastNames")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("RelativeLastNames");

                    b.Property<string>("RelativeNames")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("RelativeNames");

                    b.Property<string>("RelativePaltformName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("RelativePaltformName");

                    b.Property<int?>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Relative");
                });

            modelBuilder.Entity("PraxedesBackend.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserDocumentNumber")
                        .HasColumnType("int");

                    b.Property<string>("UserGender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserLastNames")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserNames")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserPaltformName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PraxedesBackend.Models.Relative", b =>
                {
                    b.HasOne("PraxedesBackend.Models.User", "User")
                        .WithMany("Relatives")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FKUserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PraxedesBackend.Models.User", b =>
                {
                    b.Navigation("Relatives");
                });
#pragma warning restore 612, 618
        }
    }
}
