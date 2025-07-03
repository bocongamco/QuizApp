using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace QuizApp.Models
{
    public class Quiz
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public int TimeLimitInMinutes { get; set; }
        
        [ValidateNever]
        public List<Question> Questions { get;set; } = new();
        [ValidateNever]
        public ICollection<QuizAttempt> QuizAttempts { get; set; }
    }
}
