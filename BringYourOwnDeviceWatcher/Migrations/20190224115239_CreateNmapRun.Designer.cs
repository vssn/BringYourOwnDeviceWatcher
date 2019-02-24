﻿// <auto-generated />
using System;
using BringYourOwnDeviceWatcher.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BringYourOwnDeviceWatcher.Migrations
{
    [DbContext(typeof(NmapRunContext))]
    [Migration("20190224115239_CreateNmapRun")]
    partial class CreateNmapRun
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BringYourOwnDeviceWatcher.Models.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("HostId");

                    b.Property<string>("addr");

                    b.Property<string>("addrtype");

                    b.HasKey("AddressId");

                    b.HasIndex("HostId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("BringYourOwnDeviceWatcher.Models.Host", b =>
                {
                    b.Property<int>("HostId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("NmapRunId");

                    b.Property<int?>("StatusId");

                    b.HasKey("HostId");

                    b.HasIndex("NmapRunId");

                    b.HasIndex("StatusId");

                    b.ToTable("Hosts");
                });

            modelBuilder.Entity("BringYourOwnDeviceWatcher.Models.Hostname", b =>
                {
                    b.Property<int>("HostnameId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("HostId");

                    b.Property<string>("name");

                    b.Property<string>("type");

                    b.HasKey("HostnameId");

                    b.HasIndex("HostId");

                    b.ToTable("Hostnames");
                });

            modelBuilder.Entity("BringYourOwnDeviceWatcher.Models.NmapRun", b =>
                {
                    b.Property<int>("NmapRunId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("VerboseId");

                    b.HasKey("NmapRunId");

                    b.HasIndex("VerboseId");

                    b.ToTable("NmapRuns");
                });

            modelBuilder.Entity("BringYourOwnDeviceWatcher.Models.Status", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("state");

                    b.HasKey("StatusId");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("BringYourOwnDeviceWatcher.Models.Verbose", b =>
                {
                    b.Property<int>("VerboseId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Level");

                    b.HasKey("VerboseId");

                    b.ToTable("Verboses");
                });

            modelBuilder.Entity("BringYourOwnDeviceWatcher.Models.Address", b =>
                {
                    b.HasOne("BringYourOwnDeviceWatcher.Models.Host")
                        .WithMany("Address")
                        .HasForeignKey("HostId");
                });

            modelBuilder.Entity("BringYourOwnDeviceWatcher.Models.Host", b =>
                {
                    b.HasOne("BringYourOwnDeviceWatcher.Models.NmapRun")
                        .WithMany("Host")
                        .HasForeignKey("NmapRunId");

                    b.HasOne("BringYourOwnDeviceWatcher.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");
                });

            modelBuilder.Entity("BringYourOwnDeviceWatcher.Models.Hostname", b =>
                {
                    b.HasOne("BringYourOwnDeviceWatcher.Models.Host")
                        .WithMany("Hostname")
                        .HasForeignKey("HostId");
                });

            modelBuilder.Entity("BringYourOwnDeviceWatcher.Models.NmapRun", b =>
                {
                    b.HasOne("BringYourOwnDeviceWatcher.Models.Verbose", "Verbose")
                        .WithMany()
                        .HasForeignKey("VerboseId");
                });
#pragma warning restore 612, 618
        }
    }
}
