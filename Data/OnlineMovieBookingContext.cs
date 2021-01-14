using Microsoft.EntityFrameworkCore;
using OnlineMovieBookingAPI.Models.EntityModels;
#nullable disable

namespace OnlineMovieBookingAPI.Data
{
    public partial class OnlineMovieBookingContext : DbContext
    {
        public OnlineMovieBookingContext()
        {
        }

        public OnlineMovieBookingContext(DbContextOptions<OnlineMovieBookingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BookingEntity> Bookings { get; set; }
        public virtual DbSet<CinemaEntity> Cinemas { get; set; }
        public virtual DbSet<CityEntity> Cities { get; set; }
        public virtual DbSet<HallEntity> Halls { get; set; }
        public virtual DbSet<MovieEntity> Movies { get; set; }
        public virtual DbSet<MovieScheduleEntity> MovieSchedules { get; set; }
        public virtual DbSet<ScheduleEntity> Schedules { get; set; }
        public virtual DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<BookingEntity>(entity =>
            {
                entity.ToTable("booking", "ocb");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.MovieScheduleId).HasColumnName("movie_schedule_id").IsRequired();

                entity.Property(e => e.NumberOfSeat).HasColumnName("number_of_seat").IsRequired();

                entity.Property(e => e.UserId).HasColumnName("user_id").IsRequired();

                entity.HasOne(d => d.MovieSchedule)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.MovieScheduleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_booking_movie_schedule");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_booking_user");
            });

            modelBuilder.Entity<CinemaEntity>(entity =>
            {
                entity.ToTable("cinema", "ocb");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CityId).HasColumnName("city_id").IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Cinemas)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_cinema_city");
            });

            modelBuilder.Entity<CityEntity>(entity =>
            {
                entity.ToTable("city", "ocb");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<HallEntity>(entity =>
            {
                entity.ToTable("hall", "ocb");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Capacity).HasColumnName("capacity").IsRequired();

                entity.Property(e => e.CinemaId).HasColumnName("cinema_id").IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.HasOne(d => d.Cinema)
                    .WithMany(p => p.Halls)
                    .HasForeignKey(d => d.CinemaId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_hall_cinema");
            });

            modelBuilder.Entity<MovieEntity>(entity =>
            {
                entity.ToTable("movie", "ocb");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Rating)
                    .IsRequired()
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("rating");

                entity.Property(e => e.ReleaseDate)
                    .IsRequired()
                    .HasColumnType("date")
                    .HasColumnName("release_date");
            });

            modelBuilder.Entity<MovieScheduleEntity>(entity =>
            {
                entity.ToTable("movie_schedule", "ocb");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date)
                    .IsRequired()
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.MovieId).HasColumnName("movie_id").IsRequired();

                entity.Property(e => e.ScheduleId).HasColumnName("schedule_id").IsRequired();

                entity.Property(e => e.TicketPrice).HasColumnName("ticket_price").IsRequired();

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.MovieSchedules)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_movie_schedule_movie");

                entity.HasOne(d => d.Schedule)
                    .WithMany(p => p.MovieSchedules)
                    .HasForeignKey(d => d.ScheduleId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_movie_schedule_schedule");
            });

            modelBuilder.Entity<ScheduleEntity>(entity =>
            {
                entity.ToTable("schedule", "ocb");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Day).HasColumnName("day").IsRequired();

                entity.Property(e => e.EndTime)
                    .IsRequired()
                    .HasColumnType("time(0)")
                    .HasColumnName("end_time");

                entity.Property(e => e.HallId).HasColumnName("hall_id").IsRequired();

                entity.Property(e => e.StartTime)
                    .HasColumnType("time(0)")
                    .HasColumnName("start_time");

                entity.HasOne(d => d.Hall)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.HallId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_schedule_hall");
            });

            modelBuilder.Entity<UserEntity>(entity =>
            {
                entity.ToTable("user", "ocb");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CityId).HasColumnName("city_id").IsRequired();

                entity.Property(e => e.Dateofbirth)
                    .IsRequired()
                    .HasColumnType("date")
                    .HasColumnName("dateofbirth");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("firstname");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("gender");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(50)
                    .HasColumnName("lastname");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_user_city");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
