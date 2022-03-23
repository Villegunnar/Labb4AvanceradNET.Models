﻿// <auto-generated />
using Labb4AvanceradNET.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Labb4AvanceradNET.API.Migrations
{
    [DbContext(typeof(ProgramDbContext))]
    [Migration("20220323175242_Initial Migration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Labb4AvanceradNET.Models.Interest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InterestName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Interests");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Padel is a sport which combines action with fun and social interaction. It’s a great sport for players of all ages and skills, as it is both quick and easy to pick up. Most players get the basics within the first half an hour of playing so that they can enjoy the game.",
                            InterestName = "Padel",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Description = "Golf is an individual sport played by hitting a ball with a club from a tee into a hole. The object is to get the ball into the hole with the least number of swings or strokes of the club. Golf is a hugely popular sport that is enjoyed by people of all ages.",
                            InterestName = "Golf",
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            Description = "Basketball is a game played between two teams of five players each on a rectangular court, usually indoors. Each team tries to score by tossing the ball through the opponent's goal, an elevated horizontal hoop and net called a basket.",
                            InterestName = "Basketball",
                            UserId = 1
                        },
                        new
                        {
                            Id = 4,
                            Description = "A form of high intensity interval training, CrossFit is a strength and conditioning workout that is made up of functional movement performed at a high intensity level. These movements are actions that you perform in your day-to-day life, like squatting, pulling, pushing etc.",
                            InterestName = "Crossfit",
                            UserId = 3
                        },
                        new
                        {
                            Id = 5,
                            Description = "Running is by definition the fastest means for an animal to move on foot. It is defined in sporting terms as a gait in which at some point all feet are off the ground at the same time. It is a form of both anaerobic exercise and aerobic exercise. Running is a complex, coordinated process which involves the entire body.",
                            InterestName = "Running",
                            UserId = 4
                        });
                });

            modelBuilder.Entity("Labb4AvanceradNET.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Viktor",
                            LastName = "Gunnarsson",
                            PhoneNumber = "0720043420"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Erik",
                            LastName = "Norell",
                            PhoneNumber = "0720043421"
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Lukas",
                            LastName = "Rose",
                            PhoneNumber = "0720043422"
                        },
                        new
                        {
                            Id = 4,
                            FirstName = "Erik",
                            LastName = "Risholm",
                            PhoneNumber = "0720043423"
                        });
                });

            modelBuilder.Entity("Labb4AvanceradNET.Models.Website", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("InterestId")
                        .HasColumnType("int");

                    b.Property<string>("WebbsiteAdress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WebbsiteName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("InterestId");

                    b.ToTable("Webbsites");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            InterestId = 1,
                            WebbsiteAdress = "https://www.worldpadeltour.com",
                            WebbsiteName = "World Padel Tour"
                        },
                        new
                        {
                            Id = 2,
                            InterestId = 2,
                            WebbsiteAdress = "https://www.pgatour.com",
                            WebbsiteName = "PGA Tour"
                        },
                        new
                        {
                            Id = 3,
                            InterestId = 3,
                            WebbsiteAdress = "https://www.nba.com",
                            WebbsiteName = "NBA"
                        },
                        new
                        {
                            Id = 4,
                            InterestId = 4,
                            WebbsiteAdress = "https://www.crossfit.com",
                            WebbsiteName = "Crossfit"
                        },
                        new
                        {
                            Id = 5,
                            InterestId = 5,
                            WebbsiteAdress = "https://www.runnersworld.com",
                            WebbsiteName = "Runners World"
                        });
                });

            modelBuilder.Entity("Labb4AvanceradNET.Models.Interest", b =>
                {
                    b.HasOne("Labb4AvanceradNET.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Labb4AvanceradNET.Models.Website", b =>
                {
                    b.HasOne("Labb4AvanceradNET.Models.Interest", "Interest")
                        .WithMany()
                        .HasForeignKey("InterestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}