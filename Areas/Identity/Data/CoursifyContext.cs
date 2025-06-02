using Coursify.Areas.Identity.Data;
using Coursify.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Coursify.Data;

public class CoursifyContext : IdentityDbContext<AppUser, IdentityRole, string>
{
    public CoursifyContext(DbContextOptions<CoursifyContext> options)
        : base(options)
    {
    }

    public DbSet<Course> Courses { get; set; }
    public DbSet<UserCourse> UserCourses { get; set; }
    public DbSet<UserQuiz> UserQuizzes { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<UserCourse>()
            .HasKey(uc => new { uc.UserId, uc.CourseId });

        builder.Entity<UserCourse>()
            .HasOne(uc => uc.User)
            .WithMany(u => u.UserCourses)
            .HasForeignKey(uc => uc.UserId);

        builder.Entity<UserCourse>()
            .HasOne(uc => uc.Course)
            .WithMany(c => c.UserCourses)
            .HasForeignKey(uc => uc.CourseId);

        builder.Entity<Rating>()
        .HasOne(r => r.Comment)
        .WithOne(c => c.Rating)
        .HasForeignKey<Comment>(c => c.RatingId)
        .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<UserQuiz>()
        .HasKey(uq => new { uq.UserId, uq.QuizId });

        builder.Entity<UserQuiz>()
            .HasOne(uq => uq.User)
            .WithMany(u => u.UserQuizzes)
            .HasForeignKey(uq => uq.UserId);

        builder.Entity<UserQuiz>()
            .HasOne(uq => uq.Quiz)
            .WithMany(q => q.UserQuizzes)
            .HasForeignKey(uq => uq.QuizId);
    }

public DbSet<Rating> Rating { get; set; } = default!;

public DbSet<Quiz> Quiz { get; set; } = default!;
}

