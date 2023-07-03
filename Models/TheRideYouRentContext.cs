using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TheRideYouRent_ST10083869.Models;

public partial class TheRideYouRentContext : DbContext
{
    public TheRideYouRentContext()
    {
    }

    public TheRideYouRentContext(DbContextOptions<TheRideYouRentContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<Driver> Drivers { get; set; }

    public virtual DbSet<Inspector> Inspectors { get; set; }

    public virtual DbSet<Late> Lates { get; set; }

    public virtual DbSet<Rental> Rentals { get; set; }

    public virtual DbSet<ReturnCar> ReturnCars { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=lab000000\\SQLEXPRESS;Initial Catalog=TheRideYouRent;Encrypt=False;Integrated Security=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.CarNo).HasName("PK__car__5239284260109A95");

            entity.ToTable("car");

            entity.Property(e => e.CarNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Car_no");
            entity.Property(e => e.Available)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.BodyType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Body_type");
            entity.Property(e => e.CarMake)
                .HasMaxLength(35)
                .IsUnicode(false)
                .HasColumnName("Car_make");
            entity.Property(e => e.CarModel)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Car_model");
            entity.Property(e => e.KmTravelled).HasColumnName("Km_travelled");
            entity.Property(e => e.ServiceKm).HasColumnName("Service_km");
        });

        modelBuilder.Entity<Driver>(entity =>
        {
            entity.HasKey(e => e.DriverId).HasName("PK__driver__F4614A91F68C7CE9");

            entity.ToTable("driver");

            entity.Property(e => e.DriverId).HasColumnName("Driver_id");
            entity.Property(e => e.DriverAddress)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Driver_address");
            entity.Property(e => e.DriverEmail)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Driver_email");
            entity.Property(e => e.DriverMobile)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Driver_mobile");
            entity.Property(e => e.DriverName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Driver_name");
        });

        modelBuilder.Entity<Inspector>(entity =>
        {
            entity.HasKey(e => e.InspectorId).HasName("PK__inspecto__F49FF7CD225BCB93");

            entity.ToTable("inspector");

            entity.Property(e => e.InspectorId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Inspector_id");
            entity.Property(e => e.InspectorEmail)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Inspector_email");
            entity.Property(e => e.InspectorMobile)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Inspector_Mobile");
            entity.Property(e => e.InspectorName)
                .HasMaxLength(35)
                .IsUnicode(false)
                .HasColumnName("Inspector_name");
        });

        modelBuilder.Entity<Late>(entity =>
        {
            entity.HasKey(e => e.LatefeeId).HasName("PK__late__B8D177BA1A1FC5C8");

            entity.ToTable("late");

            entity.Property(e => e.LatefeeId).HasColumnName("latefee_id");
            entity.Property(e => e.Fee).HasColumnName("FEE");
        });

        modelBuilder.Entity<Rental>(entity =>
        {
            entity.HasKey(e => e.RentalId).HasName("PK__rental__9D20A03EBE116D40");

            entity.ToTable("rental");

            entity.Property(e => e.RentalId).HasColumnName("Rental_id");
            entity.Property(e => e.CarNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Car_no");
            entity.Property(e => e.DriverId).HasColumnName("Driver_id");
            entity.Property(e => e.DriverName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Driver_name");
            entity.Property(e => e.EndDate)
                .HasColumnType("date")
                .HasColumnName("End_date");
            entity.Property(e => e.InspectorId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Inspector_id");
            entity.Property(e => e.RentalFee).HasColumnName("Rental_fee");
            entity.Property(e => e.Startdate).HasColumnType("date");

            entity.HasOne(d => d.CarNoNavigation).WithMany(p => p.Rentals)
                .HasForeignKey(d => d.CarNo)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__rental__Car_no__571DF1D5");

            entity.HasOne(d => d.Driver).WithMany(p => p.Rentals)
                .HasForeignKey(d => d.DriverId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__rental__Driver_i__59063A47");

            entity.HasOne(d => d.Inspector).WithMany(p => p.Rentals)
                .HasForeignKey(d => d.InspectorId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__rental__Inspecto__5812160E");
        });

        modelBuilder.Entity<ReturnCar>(entity =>
        {
            entity.HasKey(e => e.ReturnId).HasName("PK__return_c__0F4E406EB67E85C1");

            entity.ToTable("return_car");

            entity.Property(e => e.ReturnId).HasColumnName("Return_id");
            entity.Property(e => e.CarNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Car_no");
            entity.Property(e => e.DriverId).HasColumnName("Driver_id");
            entity.Property(e => e.DriverName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Driver_name");
            entity.Property(e => e.ElapsedDate).HasColumnName("Elapsed_date");
            entity.Property(e => e.InspectorId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Inspector_id");
            entity.Property(e => e.ReturnDate)
                .HasColumnType("date")
                .HasColumnName("Return_date");

            entity.HasOne(d => d.CarNoNavigation).WithMany(p => p.ReturnCars)
                .HasForeignKey(d => d.CarNo)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__return_ca__Car_n__60A75C0F");

            entity.HasOne(d => d.Driver).WithMany(p => p.ReturnCars)
                .HasForeignKey(d => d.DriverId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__return_ca__Drive__628FA481");

            entity.HasOne(d => d.Inspector).WithMany(p => p.ReturnCars)
                .HasForeignKey(d => d.InspectorId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__return_ca__Inspe__619B8048");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
