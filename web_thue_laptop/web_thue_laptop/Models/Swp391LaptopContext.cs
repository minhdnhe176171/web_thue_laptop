using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace web_thue_laptop.Models;

public partial class Swp391LaptopContext : DbContext
{
    public Swp391LaptopContext()
    {
    }

    public Swp391LaptopContext(DbContextOptions<Swp391LaptopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<BookingTechnicalTicket> BookingTechnicalTickets { get; set; }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Laptop> Laptops { get; set; }

    public virtual DbSet<LaptopApproval> LaptopApprovals { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server =DESKTOP-FHDMQHT; database = swp391_laptop;uid=sa;pwd=123;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BOOKING__3214EC279E6B9313");

            entity.ToTable("BOOKING");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ApprovedBy).HasColumnName("APPROVED_BY");
            entity.Property(e => e.CreatedBy).HasColumnName("CREATED_BY");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DATE");
            entity.Property(e => e.LaptopId).HasColumnName("LAPTOP_ID");
            entity.Property(e => e.StatusId).HasColumnName("STATUS_ID");
            entity.Property(e => e.TotalTime).HasColumnName("TOTAL_TIME");

            entity.HasOne(d => d.ApprovedByNavigation).WithMany(p => p.BookingApprovedByNavigations)
                .HasForeignKey(d => d.ApprovedBy)
                .HasConstraintName("FK__BOOKING__APPROVE__4F7CD00D");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.BookingCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BOOKING__CREATED__5070F446");

            entity.HasOne(d => d.Laptop).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.LaptopId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BOOKING__LAPTOP___5165187F");

            entity.HasOne(d => d.Status).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BOOKING__STATUS___52593CB8");
        });

        modelBuilder.Entity<BookingTechnicalTicket>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BOOKING___3214EC27E4ECD2A5");

            entity.ToTable("BOOKING_TECHNICAL_TICKET");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ApprovedBy).HasColumnName("APPROVED_BY");
            entity.Property(e => e.BookingId).HasColumnName("BOOKING_ID");
            entity.Property(e => e.CreatedBy).HasColumnName("CREATED_BY");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DATE");
            entity.Property(e => e.Description).HasColumnName("DESCRIPTION");
            entity.Property(e => e.Response)
                .HasMaxLength(255)
                .HasColumnName("RESPONSE");
            entity.Property(e => e.StatusId).HasColumnName("STATUS_ID");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("UPDATED_DATE");

            entity.HasOne(d => d.ApprovedByNavigation).WithMany(p => p.BookingTechnicalTicketApprovedByNavigations)
                .HasForeignKey(d => d.ApprovedBy)
                .HasConstraintName("FK__BOOKING_T__APPRO__534D60F1");

            entity.HasOne(d => d.Booking).WithMany(p => p.BookingTechnicalTickets)
                .HasForeignKey(d => d.BookingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BOOKING_T__BOOKI__5441852A");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.BookingTechnicalTicketCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BOOKING_T__CREAT__5535A963");

            entity.HasOne(d => d.Status).WithMany(p => p.BookingTechnicalTickets)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BOOKING_T__STATU__5629CD9C");
        });

        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BRAND__3214EC274692C57B");

            entity.ToTable("BRAND");

            entity.HasIndex(e => e.Name, "UQ__BRAND__D9C1FA00551AE2D5").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("NAME");
        });

        modelBuilder.Entity<Laptop>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LAPTOP__3214EC27D9EFEDA2");

            entity.ToTable("LAPTOP");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ApprovedBy).HasColumnName("APPROVED_BY");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DATE");
            entity.Property(e => e.ImgUrl)
                .HasMaxLength(500)
                .HasColumnName("IMG_URL");
            entity.Property(e => e.LaptopBrand).HasColumnName("LAPTOP_BRAND");
            entity.Property(e => e.LaptopName)
                .HasMaxLength(255)
                .HasColumnName("LAPTOP_NAME");
            entity.Property(e => e.OwnerId).HasColumnName("OWNER_ID");
            entity.Property(e => e.PricePerHour)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("PRICE_PER_HOUR");
            entity.Property(e => e.StatusId).HasColumnName("STATUS_ID");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("UPDATED_DATE");

            entity.HasOne(d => d.ApprovedByNavigation).WithMany(p => p.LaptopApprovedByNavigations)
                .HasForeignKey(d => d.ApprovedBy)
                .HasConstraintName("FK__LAPTOP__APPROVED__571DF1D5");

            entity.HasOne(d => d.LaptopBrandNavigation).WithMany(p => p.Laptops)
                .HasForeignKey(d => d.LaptopBrand)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LAPTOP__LAPTOP_B__5812160E");

            entity.HasOne(d => d.Owner).WithMany(p => p.LaptopOwners)
                .HasForeignKey(d => d.OwnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LAPTOP__OWNER_ID__59063A47");

            entity.HasOne(d => d.Status).WithMany(p => p.Laptops)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LAPTOP__STATUS_I__59FA5E80");
        });

        modelBuilder.Entity<LaptopApproval>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LAPTOP_A__3214EC277E077832");

            entity.ToTable("LAPTOP_APPROVAL");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DATE");
            entity.Property(e => e.ImgUrl)
                .HasMaxLength(500)
                .HasColumnName("IMG_URL");
            entity.Property(e => e.LaptopBrand).HasColumnName("LAPTOP_BRAND");
            entity.Property(e => e.LaptopName)
                .HasMaxLength(255)
                .HasColumnName("LAPTOP_NAME");
            entity.Property(e => e.OwnerId).HasColumnName("OWNER_ID");
            entity.Property(e => e.StatusId).HasColumnName("STATUS_ID");

            entity.HasOne(d => d.LaptopBrandNavigation).WithMany(p => p.LaptopApprovals)
                .HasForeignKey(d => d.LaptopBrand)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LAPTOP_AP__LAPTO__5AEE82B9");

            entity.HasOne(d => d.Owner).WithMany(p => p.LaptopApprovals)
                .HasForeignKey(d => d.OwnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LAPTOP_AP__OWNER__5BE2A6F2");

            entity.HasOne(d => d.Status).WithMany(p => p.LaptopApprovals)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LAPTOP_AP__STATU__5CD6CB2B");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ROLE__3214EC273A750171");

            entity.ToTable("ROLE");

            entity.HasIndex(e => e.RoleName, "UQ__ROLE__2B9B877EA44841A2").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.RoleName)
                .HasMaxLength(255)
                .HasColumnName("ROLE_NAME");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__STATUS__3214EC276B5668AC");

            entity.ToTable("STATUS");

            entity.HasIndex(e => e.StatusName, "UQ__STATUS__064B2D2D8A56E201").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.StatusName)
                .HasMaxLength(100)
                .HasColumnName("STATUS_NAME");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__USER__3214EC27AEB9FC8E");

            entity.ToTable("USER");

            entity.HasIndex(e => e.Email, "UQ__USER__161CF7246380D7E5").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DATE");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("EMAIL");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .HasColumnName("FIRST_NAME");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .HasColumnName("LAST_NAME");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("PHONE");
            entity.Property(e => e.Status).HasColumnName("STATUS");

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UserRole",
                    r => r.HasOne<Role>().WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_USER_ROLE_ROLE"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_USER_ROLE_USER"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("USER_ROLE");
                        j.IndexerProperty<long>("UserId").HasColumnName("USER_ID");
                        j.IndexerProperty<long>("RoleId").HasColumnName("ROLE_ID");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
