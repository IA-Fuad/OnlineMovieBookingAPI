﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineMovieBookingAPI.Data;

namespace OnlineMovieBookingAPI.Migrations
{
    [DbContext(typeof(OnlineMovieBookingContext))]
    [Migration("20210114131037_Requirements")]
    partial class Requirements
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("OnlineMovieBookingAPI.Models.EntityModels.BookingEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .UseIdentityColumn();

                    b.Property<int>("MovieScheduleId")
                        .HasColumnType("int")
                        .HasColumnName("movie_schedule_id");

                    b.Property<int>("NumberOfSeat")
                        .HasColumnType("int")
                        .HasColumnName("number_of_seat");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("MovieScheduleId");

                    b.HasIndex("UserId");

                    b.ToTable("booking", "ocb");
                });

            modelBuilder.Entity("OnlineMovieBookingAPI.Models.EntityModels.CinemaEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .UseIdentityColumn();

                    b.Property<int>("CityId")
                        .HasColumnType("int")
                        .HasColumnName("city_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("cinema", "ocb");
                });

            modelBuilder.Entity("OnlineMovieBookingAPI.Models.EntityModels.CityEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("city", "ocb");
                });

            modelBuilder.Entity("OnlineMovieBookingAPI.Models.EntityModels.HallEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .UseIdentityColumn();

                    b.Property<int>("Capacity")
                        .HasColumnType("int")
                        .HasColumnName("capacity");

                    b.Property<int>("CinemaId")
                        .HasColumnType("int")
                        .HasColumnName("cinema_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("CinemaId");

                    b.ToTable("hall", "ocb");
                });

            modelBuilder.Entity("OnlineMovieBookingAPI.Models.EntityModels.MovieEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.Property<decimal>("Rating")
                        .HasColumnType("decimal(4,2)")
                        .HasColumnName("rating");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("date")
                        .HasColumnName("release_date");

                    b.HasKey("Id");

                    b.ToTable("movie", "ocb");
                });

            modelBuilder.Entity("OnlineMovieBookingAPI.Models.EntityModels.MovieScheduleEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Date")
                        .HasColumnType("date")
                        .HasColumnName("date");

                    b.Property<int>("MovieId")
                        .HasColumnType("int")
                        .HasColumnName("movie_id");

                    b.Property<int>("ScheduleId")
                        .HasColumnType("int")
                        .HasColumnName("schedule_id");

                    b.Property<int>("TicketPrice")
                        .HasColumnType("int")
                        .HasColumnName("ticket_price");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.HasIndex("ScheduleId");

                    b.ToTable("movie_schedule", "ocb");
                });

            modelBuilder.Entity("OnlineMovieBookingAPI.Models.EntityModels.ScheduleEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .UseIdentityColumn();

                    b.Property<int>("Day")
                        .HasColumnType("int")
                        .HasColumnName("day");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("time(0)")
                        .HasColumnName("end_time");

                    b.Property<int>("HallId")
                        .HasColumnType("int")
                        .HasColumnName("hall_id");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time(0)")
                        .HasColumnName("start_time");

                    b.HasKey("Id");

                    b.HasIndex("HallId");

                    b.ToTable("schedule", "ocb");
                });

            modelBuilder.Entity("OnlineMovieBookingAPI.Models.EntityModels.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .UseIdentityColumn();

                    b.Property<int>("CityId")
                        .HasColumnType("int")
                        .HasColumnName("city_id");

                    b.Property<DateTime?>("Dateofbirth")
                        .IsRequired()
                        .HasColumnType("date")
                        .HasColumnName("dateofbirth");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("firstname");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("gender");

                    b.Property<string>("Lastname")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("lastname");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("user", "ocb");
                });

            modelBuilder.Entity("OnlineMovieBookingAPI.Models.EntityModels.BookingEntity", b =>
                {
                    b.HasOne("OnlineMovieBookingAPI.Models.EntityModels.MovieScheduleEntity", "MovieSchedule")
                        .WithMany("Bookings")
                        .HasForeignKey("MovieScheduleId")
                        .HasConstraintName("FK_booking_movie_schedule")
                        .IsRequired();

                    b.HasOne("OnlineMovieBookingAPI.Models.EntityModels.UserEntity", "User")
                        .WithMany("Bookings")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_booking_user")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MovieSchedule");

                    b.Navigation("User");
                });

            modelBuilder.Entity("OnlineMovieBookingAPI.Models.EntityModels.CinemaEntity", b =>
                {
                    b.HasOne("OnlineMovieBookingAPI.Models.EntityModels.CityEntity", "City")
                        .WithMany("Cinemas")
                        .HasForeignKey("CityId")
                        .HasConstraintName("FK_cinema_city")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("OnlineMovieBookingAPI.Models.EntityModels.HallEntity", b =>
                {
                    b.HasOne("OnlineMovieBookingAPI.Models.EntityModels.CinemaEntity", "Cinema")
                        .WithMany("Halls")
                        .HasForeignKey("CinemaId")
                        .HasConstraintName("FK_hall_cinema")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cinema");
                });

            modelBuilder.Entity("OnlineMovieBookingAPI.Models.EntityModels.MovieScheduleEntity", b =>
                {
                    b.HasOne("OnlineMovieBookingAPI.Models.EntityModels.MovieEntity", "Movie")
                        .WithMany("MovieSchedules")
                        .HasForeignKey("MovieId")
                        .HasConstraintName("FK_movie_schedule_movie")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineMovieBookingAPI.Models.EntityModels.ScheduleEntity", "Schedule")
                        .WithMany("MovieSchedules")
                        .HasForeignKey("ScheduleId")
                        .HasConstraintName("FK_movie_schedule_schedule")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("Schedule");
                });

            modelBuilder.Entity("OnlineMovieBookingAPI.Models.EntityModels.ScheduleEntity", b =>
                {
                    b.HasOne("OnlineMovieBookingAPI.Models.EntityModels.HallEntity", "Hall")
                        .WithMany("Schedules")
                        .HasForeignKey("HallId")
                        .HasConstraintName("FK_schedule_hall")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hall");
                });

            modelBuilder.Entity("OnlineMovieBookingAPI.Models.EntityModels.UserEntity", b =>
                {
                    b.HasOne("OnlineMovieBookingAPI.Models.EntityModels.CityEntity", "City")
                        .WithMany("Users")
                        .HasForeignKey("CityId")
                        .HasConstraintName("FK_user_city")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("OnlineMovieBookingAPI.Models.EntityModels.CinemaEntity", b =>
                {
                    b.Navigation("Halls");
                });

            modelBuilder.Entity("OnlineMovieBookingAPI.Models.EntityModels.CityEntity", b =>
                {
                    b.Navigation("Cinemas");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("OnlineMovieBookingAPI.Models.EntityModels.HallEntity", b =>
                {
                    b.Navigation("Schedules");
                });

            modelBuilder.Entity("OnlineMovieBookingAPI.Models.EntityModels.MovieEntity", b =>
                {
                    b.Navigation("MovieSchedules");
                });

            modelBuilder.Entity("OnlineMovieBookingAPI.Models.EntityModels.MovieScheduleEntity", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("OnlineMovieBookingAPI.Models.EntityModels.ScheduleEntity", b =>
                {
                    b.Navigation("MovieSchedules");
                });

            modelBuilder.Entity("OnlineMovieBookingAPI.Models.EntityModels.UserEntity", b =>
                {
                    b.Navigation("Bookings");
                });
#pragma warning restore 612, 618
        }
    }
}