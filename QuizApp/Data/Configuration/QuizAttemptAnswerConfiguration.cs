using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizApp.Models;

namespace QuizApp.Data.Configuration
{
    public class QuizAttemptAnswerConfiguration : IEntityTypeConfiguration<QuizAttemptAnswer>
    {
        public void Configure(EntityTypeBuilder<QuizAttemptAnswer> builder)
        {
            builder.HasKey(qa => qa.Id);

            builder.HasOne(a => a.QuizAttempt)
              .WithMany(a => a.Answers)
              .HasForeignKey(a => a.QuizAttemptId)
              .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(a => a.Question)
                   .WithMany()
                   .HasForeignKey(a => a.QuestionId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.SelectedAnswerOption)
                   .WithMany()
                   .HasForeignKey(a => a.SelectedAnswerOptionId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
