using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace dacodes.Models
{
    public partial class dacodesdbContext : DbContext
    {
        public dacodesdbContext()
        {
        }

        public dacodesdbContext(DbContextOptions<dacodesdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Answer> Answer { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Lesson> Lesson { get; set; }
        public virtual DbSet<Question> Question { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(local);Initial Catalog=dacodesdb;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>(entity =>
            {
                entity.ToTable("answer");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Answer1)
                    .IsRequired()
                    .HasColumnName("answer")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Idquestion).HasColumnName("idquestion");

                entity.Property(e => e.IsCorrect).HasColumnName("isCorrect");

                entity.HasOne(d => d.IdquestionNavigation)
                    .WithMany(p => p.Answer)
                    .HasForeignKey(d => d.Idquestion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_answer_question");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("course");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdCorrelative).HasColumnName("idCorrelative");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Lesson>(entity =>
            {
                entity.ToTable("lesson");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Aprovatory)
                    .HasColumnName("aprovatory")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.IdCorrelative).HasColumnName("idCorrelative");

                entity.Property(e => e.IdCourse).HasColumnName("idCourse");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCourseNavigation)
                    .WithMany(p => p.Lesson)
                    .HasForeignKey(d => d.IdCourse)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_lesson_course");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.ToTable("question");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Idlesson).HasColumnName("idlesson");

                entity.Property(e => e.Question1)
                    .IsRequired()
                    .HasColumnName("question")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdlessonNavigation)
                    .WithMany(p => p.Question)
                    .HasForeignKey(d => d.Idlesson)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_question_lesson");
            });
        }
    }
}
