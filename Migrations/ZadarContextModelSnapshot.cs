﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ZadarAPI.Models;

#nullable disable

namespace ZadarAPI.Migrations
{
    [DbContext(typeof(ZadarContext))]
    partial class ZadarContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ZadarAPI.Models.Kvart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("LifeQuality")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Kvarts", (string)null);
                });

            modelBuilder.Entity("ZadarAPI.Models.Street", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("KvartId")
                        .HasColumnType("int");

                    b.Property<float>("Lenght")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfHomes")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KvartId");

                    b.ToTable("Streets", (string)null);
                });

            modelBuilder.Entity("ZadarAPI.Models.Street", b =>
                {
                    b.HasOne("ZadarAPI.Models.Kvart", "Kvart")
                        .WithMany("Streets")
                        .HasForeignKey("KvartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kvart");
                });

            modelBuilder.Entity("ZadarAPI.Models.Kvart", b =>
                {
                    b.Navigation("Streets");
                });
#pragma warning restore 612, 618
        }
    }
}
