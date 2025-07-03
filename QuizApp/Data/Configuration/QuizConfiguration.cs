using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizApp.Models;

namespace QuizApp.Data.Configuration
{
    public class QuizConfiguration : IEntityTypeConfiguration<Quiz>
    {
        public void Configure(EntityTypeBuilder<Quiz> builder)
        {
            builder.HasKey(q => q.Id);
            builder.Property(q => q.Title)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(q => q.TimeLimitInMinutes).IsRequired();

        }
    }
}
