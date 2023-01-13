using System;
using System.Collections.Generic;
using ILibrary.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ILibrary.DAL.Context;

public partial class IlibraryContext : DbContext
{
    public IlibraryContext()
    {
        Database.EnsureCreatedAsync();
    }

    public IlibraryContext(DbContextOptions<IlibraryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Issuance> Issuances { get; set; }

    public virtual DbSet<Publishing> Publishings { get; set; }

    public virtual DbSet<Reader> Readers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog = ILIBRARY;Integrated Security=True;TrustServerCertificate = true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__AUTHOR__AA1D4378D7B13A5C");

            entity.ToTable("AUTHOR");

            entity.Property(e => e.Code).HasColumnName("CODE");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.Patronymic)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("PATRONYMIC");
            entity.Property(e => e.Surname)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("SURNAME");
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__BOOKS__AA1D4378A99CEDCC");

            entity.ToTable("BOOKS");

            entity.Property(e => e.Code)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("CODE");
            entity.Property(e => e.AuthorCode).HasColumnName("AUTHOR_CODE");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("PRICE");
            entity.Property(e => e.PublishingCode).HasColumnName("PUBLISHING_CODE");
            entity.Property(e => e.PublishingYear)
                .HasColumnType("date")
                .HasColumnName("PUBLISHING_YEAR");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TITLE");
            entity.Property(e => e.Volume).HasColumnName("VOLUME");

            entity.HasOne(d => d.AuthorCodeNavigation).WithMany(p => p.Books)
                .HasForeignKey(d => d.AuthorCode)
                .HasConstraintName("FK__BOOKS__AUTHOR_CO__2E1BDC42");

            entity.HasOne(d => d.PublishingCodeNavigation).WithMany(p => p.Books)
                .HasForeignKey(d => d.PublishingCode)
                .HasConstraintName("FK__BOOKS__PUBLISHIN__2F10007B");
        });

        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__BOOKING__AA1D4378477D9531");

            entity.ToTable("BOOKING");

            entity.Property(e => e.Code).HasColumnName("CODE");
            entity.Property(e => e.BookCode)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("BOOK_CODE");
            entity.Property(e => e.DateOfOrder)
                .HasColumnType("date")
                .HasColumnName("DATE_OF_ORDER");
            entity.Property(e => e.ReaderCode)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("READER_CODE");

            entity.HasOne(d => d.BookCodeNavigation).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.BookCode)
                .HasConstraintName("FK__BOOKING__BOOK_CO__33D4B598");

            entity.HasOne(d => d.ReaderCodeNavigation).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.ReaderCode)
                .HasConstraintName("FK__BOOKING__READER___34C8D9D1");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__CITY__AA1D43782381CECD");

            entity.ToTable("CITY");

            entity.Property(e => e.Code).HasColumnName("CODE");
            entity.Property(e => e.Description)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TITLE");
        });

        modelBuilder.Entity<Issuance>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__ISSUANCE__AA1D43787B0DE1F1");

            entity.ToTable("ISSUANCE");

            entity.Property(e => e.Code).HasColumnName("CODE");
            entity.Property(e => e.BookCode)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("BOOK_CODE");
            entity.Property(e => e.DateOfIssue)
                .HasColumnType("date")
                .HasColumnName("DATE_OF_ISSUE");
            entity.Property(e => e.DateOfReturned)
                .HasColumnType("date")
                .HasColumnName("DATE_OF_RETURNED");
            entity.Property(e => e.ReaderCode)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("READER_CODE");

            entity.HasOne(d => d.BookCodeNavigation).WithMany(p => p.Issuances)
                .HasForeignKey(d => d.BookCode)
                .HasConstraintName("FK__ISSUANCE__BOOK_C__37A5467C");

            entity.HasOne(d => d.ReaderCodeNavigation).WithMany(p => p.Issuances)
                .HasForeignKey(d => d.ReaderCode)
                .HasConstraintName("FK__ISSUANCE__READER__38996AB5");
        });

        modelBuilder.Entity<Publishing>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__PUBLISHI__AA1D437811B686FE");

            entity.ToTable("PUBLISHING");

            entity.Property(e => e.Code)
                .ValueGeneratedNever()
                .HasColumnName("CODE");
            entity.Property(e => e.CityCode).HasColumnName("CITY_CODE");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TITLE");

            entity.HasOne(d => d.CityCodeNavigation).WithMany(p => p.Publishings)
                .HasForeignKey(d => d.CityCode)
                .HasConstraintName("FK__PUBLISHIN__CITY___2B3F6F97");
        });

        modelBuilder.Entity<Reader>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__READER__AA1D437814378284");

            entity.ToTable("READER");

            entity.Property(e => e.Code)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("CODE");
            entity.Property(e => e.Address)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("ADDRESS");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.Number).HasColumnName("NUMBER");
            entity.Property(e => e.Patronymic)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("PATRONYMIC");
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SURNAME");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
