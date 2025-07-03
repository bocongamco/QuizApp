using QuizApp.Models;

namespace QuizApp.Services
{
    public interface IQuizService
    {
        Task<Quiz> GetQuizWithQuestionsAsync(Guid quizId);
        int CalculateScore(Quiz quiz, Dictionary<Guid, Guid> submittedAnswers);


    }
}
