namespace QuizApp.ViewModel
{
    public class QuizAttemptViewModel
    {
        public Guid QuizId { get; set; }
        public List<QuestionAttempt> Questions { get; set; } = new();

    }
    public class QuestionAttempt
    {
        public Guid QuestionId { get; set; }
        public Guid SelectedAnswerId { get; set; }
    }
}
