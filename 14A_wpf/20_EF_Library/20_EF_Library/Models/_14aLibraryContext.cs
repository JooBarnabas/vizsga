using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace _20_EF_Library.Models;

public partial class _14aLibraryContext : DbContext
{
    public _14aLibraryContext()
    {
    }

    public _14aLibraryContext(DbContextOptions<_14aLibraryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Borrow> Borrows { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Types> Types { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseMySql("server=localhost;database=14A_library;uid=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.28-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8_unicode_ci")
            .HasCharSet("utf8");

        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.AuthorId).HasName("PRIMARY");

            entity.ToTable("authors");

            entity.Property(e => e.AuthorId)
                .HasColumnType("int(11)")
                .HasColumnName("authorId");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Surname)
                .HasMaxLength(70)
                .HasColumnName("surname");
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.BookId).HasName("PRIMARY");

            entity.ToTable("books");

            entity.HasIndex(e => e.AuthorId, "authorId");

            entity.HasIndex(e => e.TypeId, "typeId");

            entity.Property(e => e.BookId)
                .HasColumnType("int(11)")
                .HasColumnName("bookId");
            entity.Property(e => e.AuthorId)
                .HasColumnType("int(11)")
                .HasColumnName("authorId");
            entity.Property(e => e.Name)
                .HasMaxLength(90)
                .HasColumnName("name");
            entity.Property(e => e.Pagecount)
                .HasColumnType("int(11)")
                .HasColumnName("pagecount");
            entity.Property(e => e.Point)
                .HasColumnType("int(11)")
                .HasColumnName("point");
            entity.Property(e => e.TypeId)
                .HasColumnType("int(11)")
                .HasColumnName("typeId");

            entity.HasOne(d => d.Author).WithMany(p => p.Books)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("books_ibfk_1");

            entity.HasOne(d => d.Types).WithMany(p => p.Books)
                .HasForeignKey(d => d.TypeId)
                .HasConstraintName("books_type_1");
        });

        modelBuilder.Entity<Borrow>(entity =>
        {
            entity.HasKey(e => e.BorrowId).HasName("PRIMARY");

            entity.ToTable("borrows");

            entity.HasIndex(e => e.BookId, "bookId");

            entity.HasIndex(e => e.StudentId, "studentId");

            entity.Property(e => e.BorrowId)
                .HasColumnType("int(11)")
                .HasColumnName("borrowId");
            entity.Property(e => e.BookId)
                .HasColumnType("int(11)")
                .HasColumnName("bookId");
            entity.Property(e => e.BroughtDate)
                .HasColumnType("datetime(3)")
                .HasColumnName("broughtDate");
            entity.Property(e => e.StudentId)
                .HasColumnType("int(11)")
                .HasColumnName("studentId");
            entity.Property(e => e.TakenDate)
                .HasColumnType("datetime(3)")
                .HasColumnName("takenDate");

            entity.HasOne(d => d.Book).WithMany(p => p.Borrows)
                .HasForeignKey(d => d.BookId)
                .HasConstraintName("borrows_book_1");

            entity.HasOne(d => d.Student).WithMany(p => p.Borrows)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("borrows_student_1");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PRIMARY");

            entity.ToTable("students");

            entity.Property(e => e.StudentId)
                .HasColumnType("int(11)")
                .HasColumnName("studentId");
            entity.Property(e => e.Birthdate).HasColumnName("birthdate");
            entity.Property(e => e.Class)
                .HasMaxLength(7)
                .HasColumnName("class");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .HasColumnName("gender");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .HasColumnName("name");
            entity.Property(e => e.Point)
                .HasColumnType("int(11)")
                .HasColumnName("point");
            entity.Property(e => e.Surname)
                .HasMaxLength(20)
                .HasColumnName("surname");
        });

        modelBuilder.Entity<Types>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("PRIMARY");

            entity.ToTable("types");

            entity.Property(e => e.TypeId)
                .HasColumnType("int(11)")
                .HasColumnName("typeId");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
