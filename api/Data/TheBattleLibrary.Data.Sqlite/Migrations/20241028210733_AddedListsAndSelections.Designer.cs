﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TheBattleLibrary.Data;

#nullable disable

namespace TheBattleLibrary.Data.Sqlite.Migrations
{
    [DbContext(typeof(SqliteDbContext))]
    [Migration("20241028210733_AddedListsAndSelections")]
    partial class AddedListsAndSelections
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("TheBattleLibrary.Data.Entities.BattleList", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Faction")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("BattleLists");
                });

            modelBuilder.Entity("TheBattleLibrary.Data.Entities.Selection", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ParentListId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ParentSelectionId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ParentListId");

                    b.HasIndex("ParentSelectionId");

                    b.ToTable("Selections");
                });

            modelBuilder.Entity("TheBattleLibrary.Data.Entities.UserAccount", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TheBattleLibrary.Data.Entities.Selection", b =>
                {
                    b.HasOne("TheBattleLibrary.Data.Entities.BattleList", "ParentList")
                        .WithMany("Selections")
                        .HasForeignKey("ParentListId");

                    b.HasOne("TheBattleLibrary.Data.Entities.Selection", "ParentSelection")
                        .WithMany("ChildSelections")
                        .HasForeignKey("ParentSelectionId");

                    b.Navigation("ParentList");

                    b.Navigation("ParentSelection");
                });

            modelBuilder.Entity("TheBattleLibrary.Data.Entities.BattleList", b =>
                {
                    b.Navigation("Selections");
                });

            modelBuilder.Entity("TheBattleLibrary.Data.Entities.Selection", b =>
                {
                    b.Navigation("ChildSelections");
                });
#pragma warning restore 612, 618
        }
    }
}
