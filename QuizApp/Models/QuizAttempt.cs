namespace QuizApp.Models
{
    public class QuizAttempt
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime TimeAttempt {  get; set; }
        public int score { get; set; }
        public Guid QuizId { get; set; }
        public Quiz Quiz { get; set; }
        public ICollection<QuizAttemptAnswer> Answers { get; set; }

    }
}
