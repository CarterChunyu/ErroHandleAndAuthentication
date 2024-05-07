﻿// <auto-generated />
using ErrorHandlerandAuthetication.DBContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ErrorHandlerandAuthetication.Migrations
{
    [DbContext(typeof(ProjectContext))]
    partial class ProjectContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ErrorHandlerandAuthetication.Models.Group", b =>
                {
                    b.Property<string>("GroupId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("GroupName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GroupId");

                    b.ToTable("Groups");

                    b.HasData(
                        new
                        {
                            GroupId = "T001",
                            GroupName = "管理者"
                        },
                        new
                        {
                            GroupId = "T002",
                            GroupName = "聯徵發查"
                        });
                });

            modelBuilder.Entity("ErrorHandlerandAuthetication.Models.MenuCode", b =>
                {
                    b.Property<int>("FunctionSeq")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FunctionSeq"));

                    b.Property<string>("DetailFunctionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GroupId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MainFuncionName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FunctionSeq");

                    b.ToTable("MenuCodes");

                    b.HasData(
                        new
                        {
                            FunctionSeq = 1,
                            DetailFunctionName = "Index1",
                            GroupId = "T001",
                            MainFuncionName = "Test"
                        },
                        new
                        {
                            FunctionSeq = 2,
                            DetailFunctionName = "Index1",
                            GroupId = "T002",
                            MainFuncionName = "Test"
                        },
                        new
                        {
                            FunctionSeq = 3,
                            DetailFunctionName = "Index2",
                            GroupId = "T001",
                            MainFuncionName = "Test"
                        },
                        new
                        {
                            FunctionSeq = 4,
                            DetailFunctionName = "Index1",
                            GroupId = "T001",
                            MainFuncionName = "TestApi"
                        });
                });

            modelBuilder.Entity("ErrorHandlerandAuthetication.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Account")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GroupId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Account = "tnfe01",
                            GroupId = "T001",
                            Password = "@a0123456789",
                            UserName = "chunyu"
                        },
                        new
                        {
                            UserId = 2,
                            Account = "tnfe02",
                            GroupId = "T002",
                            Password = "@a0123456789",
                            UserName = "dru"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
