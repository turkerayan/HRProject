﻿// <auto-generated />
using System;
using IkProject.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IkProject.Persistence.Migrations
{
    [DbContext(typeof(IkPorjectDbContext))]
    partial class IkPorjectDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("IkProject.Domain.Company.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ContractEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ContractStartDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EstablishmentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImgPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MersisNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("TaxAdministration")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaxNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Companies");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b28c70eb-112f-44d0-a0a3-4b7c4f2931d1"),
                            Address = "İstanbul",
                            ContractEndDate = new DateTime(2026, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ContractStartDate = new DateTime(2021, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Created = new DateTime(2024, 7, 2, 3, 27, 3, 864, DateTimeKind.Local).AddTicks(6893),
                            Email = "bilgeadammain@bilgeadam.com",
                            EstablishmentDate = new DateTime(1999, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MersisNo = "4532453245324532",
                            Name = "Bilgeadam",
                            PhoneNumber = "+905432175485",
                            Status = 1,
                            TaxAdministration = "İstanbul Vergi Dairesi",
                            TaxNo = "3453234532"
                        });
                });

            modelBuilder.Entity("IkProject.Domain.Identities.AppRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("2355ccfb-5e9e-4a8c-972d-384fb2315457"),
                            Name = "CompanyManager",
                            NormalizedName = "COMPANYMANAGER"
                        },
                        new
                        {
                            Id = new Guid("7865269f-01b8-4d28-9c07-645245ce9a1e"),
                            Name = "Personal",
                            NormalizedName = "PERSONAL"
                        },
                        new
                        {
                            Id = new Guid("093f1aca-7fde-44a4-88de-0bdb9a1f96ae"),
                            Name = "SiteManager",
                            NormalizedName = "SITEMANAGER"
                        });
                });

            modelBuilder.Entity("IkProject.Domain.Identities.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("IdentityNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImgPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsBoy")
                        .HasColumnType("bit");

                    b.Property<string>("Job")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LeavingJob")
                        .HasColumnType("datetime2");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("PlaceOfBirth")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondSurname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("StartAJob")
                        .HasColumnType("datetime2");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<decimal>("Wage")
                        .HasColumnType("decimal(28, 6)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("AppUser");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("IkProject.Domain.Requests.AdvancePayment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ApprovalStatus")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("Currency")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Money")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ResponseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ResponseDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AdvancePayments");
                });

            modelBuilder.Entity("IkProject.Domain.Requests.Expense", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ApprovalStatus")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("Currency")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Money")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ResponseDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("IkProject.Domain.Requests.PermissionRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AppUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ApprovalStatus")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NumberOfDay")
                        .HasColumnType("int");

                    b.Property<DateTime>("PermissionEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PermissionStart")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PermissionTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ReplyDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("PermissionTypeId");

                    b.ToTable("PermissionRequests");
                });

            modelBuilder.Entity("IkProject.Domain.Requests.PermissionType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("datetime2");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("PermissionTypes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("945e2b85-36ea-4947-bf8a-002c7d97b9d1"),
                            Created = new DateTime(2024, 7, 2, 3, 27, 3, 864, DateTimeKind.Local).AddTicks(6710),
                            Gender = 3,
                            Name = "Yıllık izin",
                            Status = 1
                        },
                        new
                        {
                            Id = new Guid("ae5d8436-9e77-40fc-8e14-f8ff49bca5c3"),
                            Created = new DateTime(2024, 7, 2, 3, 27, 3, 864, DateTimeKind.Local).AddTicks(6733),
                            Gender = 1,
                            Name = "Doğum izni",
                            Status = 1
                        },
                        new
                        {
                            Id = new Guid("0db8f712-e880-45bc-898e-a4a140ef6439"),
                            Created = new DateTime(2024, 7, 2, 3, 27, 3, 864, DateTimeKind.Local).AddTicks(6743),
                            Gender = 1,
                            Name = "Süt izni",
                            Status = 1
                        },
                        new
                        {
                            Id = new Guid("6e9d4f4a-9ddb-4098-adae-e275d83c086d"),
                            Created = new DateTime(2024, 7, 2, 3, 27, 3, 864, DateTimeKind.Local).AddTicks(6752),
                            Gender = 2,
                            Name = "Babalık izni",
                            Status = 1
                        },
                        new
                        {
                            Id = new Guid("d8f07d79-2f03-4915-975d-aa167a954af3"),
                            Created = new DateTime(2024, 7, 2, 3, 27, 3, 864, DateTimeKind.Local).AddTicks(6761),
                            Gender = 3,
                            Name = "Hastalık izni",
                            Status = 1
                        },
                        new
                        {
                            Id = new Guid("668cd66d-9bf3-4ab8-8e09-6e108ed3f4bb"),
                            Created = new DateTime(2024, 7, 2, 3, 27, 3, 864, DateTimeKind.Local).AddTicks(6775),
                            Gender = 3,
                            Name = "Ölüm izni",
                            Status = 1
                        },
                        new
                        {
                            Id = new Guid("7b40b5a0-ce10-409d-95af-d22ea63e5d2a"),
                            Created = new DateTime(2024, 7, 2, 3, 27, 3, 864, DateTimeKind.Local).AddTicks(6785),
                            Gender = 3,
                            Name = "Yeni iş arama izni",
                            Status = 1
                        },
                        new
                        {
                            Id = new Guid("3ce6e2e3-a471-47ee-a4cf-343ec355096a"),
                            Created = new DateTime(2024, 7, 2, 3, 27, 3, 864, DateTimeKind.Local).AddTicks(6831),
                            Gender = 3,
                            Name = "Evlilik izni",
                            Status = 1
                        },
                        new
                        {
                            Id = new Guid("f64f5dce-a84d-4dad-8235-a5fca38ec831"),
                            Created = new DateTime(2024, 7, 2, 3, 27, 3, 864, DateTimeKind.Local).AddTicks(6840),
                            Gender = 3,
                            Name = "Evlat edinme izni",
                            Status = 1
                        },
                        new
                        {
                            Id = new Guid("b402370a-c4db-4890-9070-056d9ece33b4"),
                            Created = new DateTime(2024, 7, 2, 3, 27, 3, 864, DateTimeKind.Local).AddTicks(6850),
                            Gender = 3,
                            Name = "Mazeret izni",
                            Status = 1
                        },
                        new
                        {
                            Id = new Guid("40cc4874-ef44-47d5-bc68-56bf5dd8fbff"),
                            Created = new DateTime(2024, 7, 2, 3, 27, 3, 864, DateTimeKind.Local).AddTicks(6861),
                            Gender = 3,
                            Name = "Refakat izni",
                            Status = 1
                        },
                        new
                        {
                            Id = new Guid("f3357e7d-6c4b-455a-bf95-308fcee78e58"),
                            Created = new DateTime(2024, 7, 2, 3, 27, 3, 864, DateTimeKind.Local).AddTicks(6871),
                            Gender = 2,
                            Name = "Askerlik izni",
                            Status = 1
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("IkProject.Domain.Identities.CompanyManger", b =>
                {
                    b.HasBaseType("IkProject.Domain.Identities.AppUser");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CompanyManager_CompanyId");

                    b.HasIndex("CompanyId")
                        .IsUnique()
                        .HasFilter("[CompanyManager_CompanyId] IS NOT NULL");

                    b.HasDiscriminator().HasValue("CompanyManger");
                });

            modelBuilder.Entity("IkProject.Domain.Identities.Personal", b =>
                {
                    b.HasBaseType("IkProject.Domain.Identities.AppUser");

                    b.Property<Guid>("CompanyPersonelId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Personel_CompanyId");

                    b.HasIndex("CompanyPersonelId");

                    b.HasDiscriminator().HasValue("Personal");
                });

            modelBuilder.Entity("IkProject.Domain.Identities.SiteManager", b =>
                {
                    b.HasBaseType("IkProject.Domain.Identities.AppUser");

                    b.HasDiscriminator().HasValue("SiteManager");
                });

            modelBuilder.Entity("IkProject.Domain.Requests.AdvancePayment", b =>
                {
                    b.HasOne("IkProject.Domain.Identities.AppUser", "User")
                        .WithMany("AdvancePayments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("IkProject.Domain.Requests.Expense", b =>
                {
                    b.HasOne("IkProject.Domain.Identities.AppUser", "User")
                        .WithMany("Expenses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("IkProject.Domain.Requests.PermissionRequest", b =>
                {
                    b.HasOne("IkProject.Domain.Identities.AppUser", "AppUser")
                        .WithMany("PermissionRequests")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IkProject.Domain.Requests.PermissionType", "PermissionType")
                        .WithMany("PermissionRequests")
                        .HasForeignKey("PermissionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("PermissionType");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("IkProject.Domain.Identities.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("IkProject.Domain.Identities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("IkProject.Domain.Identities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("IkProject.Domain.Identities.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IkProject.Domain.Identities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("IkProject.Domain.Identities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IkProject.Domain.Identities.CompanyManger", b =>
                {
                    b.HasOne("IkProject.Domain.Company.Company", "Company")
                        .WithOne("CompanyManger")
                        .HasForeignKey("IkProject.Domain.Identities.CompanyManger", "CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("IkProject.Domain.Identities.Personal", b =>
                {
                    b.HasOne("IkProject.Domain.Company.Company", "CompanyPersonel")
                        .WithMany("Personels")
                        .HasForeignKey("CompanyPersonelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CompanyPersonel");
                });

            modelBuilder.Entity("IkProject.Domain.Company.Company", b =>
                {
                    b.Navigation("CompanyManger");

                    b.Navigation("Personels");
                });

            modelBuilder.Entity("IkProject.Domain.Identities.AppUser", b =>
                {
                    b.Navigation("AdvancePayments");

                    b.Navigation("Expenses");

                    b.Navigation("PermissionRequests");
                });

            modelBuilder.Entity("IkProject.Domain.Requests.PermissionType", b =>
                {
                    b.Navigation("PermissionRequests");
                });
#pragma warning restore 612, 618
        }
    }
}
