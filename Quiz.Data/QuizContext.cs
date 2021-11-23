using Quiz.Common;
using Microsoft.EntityFrameworkCore;

namespace Quiz.Data
{
    public class QuizContext : DbContext
    {
        // Overwride by dependency injection
        public QuizContext(DbContextOptions<QuizContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>().ToTable("answers");
            modelBuilder.Entity<Question>().ToTable("questions");
            modelBuilder.Entity<QuestionAnswer>().ToTable("question_answers");
            modelBuilder.Entity<QuestionExplanation>().ToTable("explanations");
        }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionAnswer> QuestionAnswer { get; set; }
        public DbSet<QuestionExplanation> QuestionExplanations { get; set; }
    }
}
