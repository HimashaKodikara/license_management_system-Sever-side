﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using license_management_system_Sever_side.Data;

#nullable disable

namespace license_management_system_Sever_side.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("license_management_system_Sever_side.Models.Entities.ClientServerInfo", b =>
                {
                    b.Property<string>("MacAddress")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("HostUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("clientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("testDate")
                        .HasColumnType("datetime2");

                    b.HasKey("MacAddress");

                    b.ToTable("ClientServerInfos");
                });

            modelBuilder.Entity("license_management_system_Sever_side.Models.Entities.ClientServerSiteName", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClientServerMacAddress")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MacAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SiteName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClientServerMacAddress");

                    b.ToTable("ClientServerSiteNames");
                });

            modelBuilder.Entity("license_management_system_Sever_side.Models.Entities.EndClient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AdditionalInfo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("City");

                    b.Property<string>("Country")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("Country");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("email");

                    b.Property<string>("HostUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Industry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MackAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("name");

                    b.Property<int>("PartnerId")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasColumnName("phone_number");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Region")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("Region");

                    b.Property<string>("Website")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PartnerId");

                    b.ToTable("EndClients");
                });

            modelBuilder.Entity("license_management_system_Sever_side.Models.Entities.LicenseKey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("key_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ActivationDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("activation_date");

                    b.Property<DateTime>("DeactivatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("deactivated_Date");

                    b.Property<string>("Key_name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Key_name");

                    b.Property<int?>("RequestID")
                        .HasColumnType("int");

                    b.Property<int?>("RequestKeyRequestID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RequestKeyRequestID");

                    b.ToTable("LicenseKey");
                });

            modelBuilder.Entity("license_management_system_Sever_side.Models.Entities.Modules", b =>
                {
                    b.Property<int>("ModulesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ModulesId"));

                    b.Property<DateTime>("CreatedData")
                        .HasColumnType("datetime2");

                    b.Property<string>("Features")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModuleDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Modulename")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("name");

                    b.HasKey("ModulesId");

                    b.ToTable("Modules");
                });

            modelBuilder.Entity("license_management_system_Sever_side.Models.Entities.RequestKey", b =>
                {
                    b.Property<int>("RequestID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("request_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RequestID"));

                    b.Property<string>("CommentFinaceMgt")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("comment_finace_mgt");

                    b.Property<string>("CommentPartnerMgt")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("comment_partner_mgt");

                    b.Property<int>("EndClientId")
                        .HasColumnType("int");

                    b.Property<int?>("FinaceManagerId")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfDays")
                        .HasColumnType("int");

                    b.Property<int>("PartnerId")
                        .HasColumnType("int");

                    b.Property<int?>("PartnerManagerID")
                        .HasColumnType("int");

                    b.Property<bool>("isFinanceApproval")
                        .HasColumnType("bit")
                        .HasColumnName("status_finance_mgt");

                    b.Property<bool>("isPartnerApproval")
                        .HasColumnType("bit")
                        .HasColumnName("status_Partner_mgt");

                    b.HasKey("RequestID");

                    b.HasIndex("EndClientId");

                    b.HasIndex("FinaceManagerId");

                    b.HasIndex("PartnerId");

                    b.HasIndex("PartnerManagerID");

                    b.ToTable("RequestKeys");
                });

            modelBuilder.Entity("license_management_system_Sever_side.Models.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("license_management_system_Sever_side.Models.Entities.FinaceManager", b =>
                {
                    b.HasBaseType("license_management_system_Sever_side.Models.Entities.User");

                    b.Property<int>("UserRole")
                        .HasColumnType("int");

                    b.Property<string>("discription")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Users", t =>
                        {
                            t.Property("UserRole")
                                .HasColumnName("FinaceManager_UserRole");

                            t.Property("discription")
                                .HasColumnName("FinaceManager_discription");
                        });

                    b.HasDiscriminator().HasValue("FinaceManager");
                });

            modelBuilder.Entity("license_management_system_Sever_side.Models.Entities.Partner", b =>
                {
                    b.HasBaseType("license_management_system_Sever_side.Models.Entities.User");

                    b.Property<int>("UserRole")
                        .HasColumnType("int");

                    b.ToTable("Users", t =>
                        {
                            t.Property("UserRole")
                                .HasColumnName("Partner_UserRole");
                        });

                    b.HasDiscriminator().HasValue("Partner");
                });

            modelBuilder.Entity("license_management_system_Sever_side.Models.Entities.PartnerManager", b =>
                {
                    b.HasBaseType("license_management_system_Sever_side.Models.Entities.User");

                    b.Property<int>("UserRole")
                        .HasColumnType("int");

                    b.Property<string>("discription")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("PartnerManager");
                });

            modelBuilder.Entity("license_management_system_Sever_side.Models.Entities.ClientServerSiteName", b =>
                {
                    b.HasOne("license_management_system_Sever_side.Models.Entities.ClientServerInfo", "ClientServer")
                        .WithMany("SiteNames")
                        .HasForeignKey("ClientServerMacAddress");

                    b.Navigation("ClientServer");
                });

            modelBuilder.Entity("license_management_system_Sever_side.Models.Entities.EndClient", b =>
                {
                    b.HasOne("license_management_system_Sever_side.Models.Entities.Partner", "Partner")
                        .WithMany("EndClients")
                        .HasForeignKey("PartnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Partner");
                });

            modelBuilder.Entity("license_management_system_Sever_side.Models.Entities.LicenseKey", b =>
                {
                    b.HasOne("license_management_system_Sever_side.Models.Entities.RequestKey", "RequestKey")
                        .WithMany()
                        .HasForeignKey("RequestKeyRequestID");

                    b.Navigation("RequestKey");
                });

            modelBuilder.Entity("license_management_system_Sever_side.Models.Entities.RequestKey", b =>
                {
                    b.HasOne("license_management_system_Sever_side.Models.Entities.EndClient", "EndClient")
                        .WithMany("RequestKeys")
                        .HasForeignKey("EndClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("license_management_system_Sever_side.Models.Entities.FinaceManager", "FinaceManager")
                        .WithMany("RequestKeys")
                        .HasForeignKey("FinaceManagerId");

                    b.HasOne("license_management_system_Sever_side.Models.Entities.Partner", "Partner")
                        .WithMany("RequestKeys")
                        .HasForeignKey("PartnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("license_management_system_Sever_side.Models.Entities.PartnerManager", "PartnerManager")
                        .WithMany("RequestKeys")
                        .HasForeignKey("PartnerManagerID");

                    b.Navigation("EndClient");

                    b.Navigation("FinaceManager");

                    b.Navigation("Partner");

                    b.Navigation("PartnerManager");
                });

            modelBuilder.Entity("license_management_system_Sever_side.Models.Entities.ClientServerInfo", b =>
                {
                    b.Navigation("SiteNames");
                });

            modelBuilder.Entity("license_management_system_Sever_side.Models.Entities.EndClient", b =>
                {
                    b.Navigation("RequestKeys");
                });

            modelBuilder.Entity("license_management_system_Sever_side.Models.Entities.FinaceManager", b =>
                {
                    b.Navigation("RequestKeys");
                });

            modelBuilder.Entity("license_management_system_Sever_side.Models.Entities.Partner", b =>
                {
                    b.Navigation("EndClients");

                    b.Navigation("RequestKeys");
                });

            modelBuilder.Entity("license_management_system_Sever_side.Models.Entities.PartnerManager", b =>
                {
                    b.Navigation("RequestKeys");
                });
#pragma warning restore 612, 618
        }
    }
}
