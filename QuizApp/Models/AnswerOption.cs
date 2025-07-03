namespace QuizApp.Models
{
    public class AnswerOption
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string AnswerText { get; set; }
        public bool isCorrect { get; set; }
        public Guid QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
