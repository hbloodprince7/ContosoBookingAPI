using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NewAPI.Models
{
    public partial class ContosoBookingContext : DbContext
    {
        public ContosoBookingContext()
        {
        }

        public ContosoBookingContext(DbContextOptions<ContosoBookingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BookingDetail> BookingDetails { get; set; } = null!;
        public virtual DbSet<EventsDetail> EventsDetails { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:mynewserver07.database.windows.net,1433;Initial Catalog=ContosoBooking;Persist Security Info=False;User ID=Bharath;Password=Qwertyuiop07@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookingDetail>(entity =>
            {
                entity.HasKey(e => e.BookingId);

                entity.ToTable("Booking_Details");

                entity.Property(e => e.BookingId).HasColumnName("Booking_Id");

                entity.Property(e => e.BookingEvent)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Booking_Event");

                entity.Property(e => e.BookingEventId).HasColumnName("Booking_EventId");

                entity.Property(e => e.BookingNumberofTickets).HasColumnName("Booking_NumberofTickets");

                entity.Property(e => e.BookingTicketCatagory)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Booking_TicketCatagory");

                entity.Property(e => e.BookingUserId).HasColumnName("Booking_User_Id");

                entity.HasOne(d => d.BookingEventNavigation)
                    .WithMany(p => p.BookingDetails)
                    .HasForeignKey(d => d.BookingEventId)
                    .HasConstraintName("FK_Booking_Details");
            });

            modelBuilder.Entity<EventsDetail>(entity =>
            {
                entity.HasKey(e => e.EventId);

                entity.ToTable("Events_Details");

                entity.Property(e => e.EventId).HasColumnName("Event_Id");

                entity.Property(e => e.EventEnddate)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Event_Enddate");

                entity.Property(e => e.EventLocation)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Event_Location");

                entity.Property(e => e.EventName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Event_Name");

                entity.Property(e => e.EventStartdate)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Event_Startdate");

                entity.Property(e => e.EventType)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Event_Type");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
