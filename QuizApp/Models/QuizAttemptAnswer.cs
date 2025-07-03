namespace QuizApp.Models
{
    public class QuizAttemptAnswer
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid QuizAttemptId { get; set; }
        public QuizAttempt QuizAttempt { get; set; }
        public Guid QuestionId {get; set; }
        public Question Question { get; set; }  
        public Guid SelectedAnswerOptionId { get; set; }
        public AnswerOption SelectedAnswerOption { get; set; }
    }
}
