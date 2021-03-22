using Microsoft.EntityFrameworkCore;
using PPDS.Core;
using PPDS.Core.Models;
using System.Collections.Generic;

namespace PPDS.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {


        }

        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionType> QuestionTypes { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<LectureType> LectureTypes { get; set; }
        public DbSet<ChoosableAnswer> ChoosableAnswers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lecture>().HasKey(e => e.Id);

            modelBuilder.Entity<Lecture>().HasOne(x => x.LectureType)
                                          .WithMany()
                                          .HasForeignKey(x => x.LectureTypeId);

            modelBuilder.Entity<Lecture>().HasMany(x => x.Questions)
                                          .WithOne()
                                          .HasForeignKey(x => x.LectureId);


            modelBuilder.Entity<Question>().HasKey(e => e.Id);

            modelBuilder.Entity<Question>().HasOne(x => x.QuestionType)
                                           .WithMany()
                                           .HasForeignKey(x => x.QuestionTypeId);

            modelBuilder.Entity<Question>().HasMany(x => x.ChoosableAnswers)
                                          .WithOne()
                                          .HasForeignKey(x => x.QuestionId);


            modelBuilder.Entity<LectureType>().HasKey(e => e.Id);

            modelBuilder.Entity<LectureType>().HasData(new List<LectureType>()
            {
                LectureType.Lecture,
                LectureType.Practise,
                
            });


            modelBuilder.Entity<QuestionType>().HasKey(e => e.Id);

            modelBuilder.Entity<QuestionType>().HasData(new List<QuestionType>()
            {
                QuestionType.Choosable
          

            });


        }
    }


}
