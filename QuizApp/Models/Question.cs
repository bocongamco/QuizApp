namespace QuizApp.Models
{
    public class Question
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string QuestionText { get; set; }
        public Guid QuizId { get; set; }
        public Quiz Quiz { get; set; }
        public ICollection<AnswerOption> AnswerOptions { get; set; } 
    }
}
