﻿// <auto-generated />
using System;
using CitrusWeb.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CitrusWeb.Api.Migrations
{
    [DbContext(typeof(CitrusUnitOfWork))]
    partial class CitrusUnitOfWorkModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CitrusWeb.Api.DataAccess.DomainObjects.PresentationModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("VideoId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("VideoId");

                    b.ToTable("Presentations");
                });

            modelBuilder.Entity("CitrusWeb.Api.DataAccess.DomainObjects.PresentationSheetModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("HtmlText")
                        .HasColumnType("text");

                    b.Property<string>("ImgUrl")
                        .HasColumnType("text");

                    b.Property<int>("PresentationId")
                        .HasColumnType("integer");

                    b.Property<int?>("TimeCodeHours")
                        .HasColumnType("integer");

                    b.Property<int?>("TimeCodeMinutes")
                        .HasColumnType("integer");

                    b.Property<int?>("TimeCodeSeconds")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PresentationId");

                    b.ToTable("PresentationSheets");
                });

            modelBuilder.Entity("CitrusWeb.Api.DataAccess.DomainObjects.VideoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Length")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Videos");
                });

            modelBuilder.Entity("CitrusWeb.Api.DataAccess.DomainObjects.PresentationModel", b =>
                {
                    b.HasOne("CitrusWeb.Api.DataAccess.DomainObjects.VideoModel", "Video")
                        .WithMany("Presentations")
                        .HasForeignKey("VideoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Video");
                });

            modelBuilder.Entity("CitrusWeb.Api.DataAccess.DomainObjects.PresentationSheetModel", b =>
                {
                    b.HasOne("CitrusWeb.Api.DataAccess.DomainObjects.PresentationModel", "Presentation")
                        .WithMany("PresentationSheets")
                        .HasForeignKey("PresentationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Presentation");
                });

            modelBuilder.Entity("CitrusWeb.Api.DataAccess.DomainObjects.PresentationModel", b =>
                {
                    b.Navigation("PresentationSheets");
                });

            modelBuilder.Entity("CitrusWeb.Api.DataAccess.DomainObjects.VideoModel", b =>
                {
                    b.Navigation("Presentations");
                });
#pragma warning restore 612, 618
        }
    }
}
