using Microsoft.EntityFrameworkCore;
using QuizApp.Data;
using QuizApp.Models;

namespace QuizApp.Services
{
    public class QuizService : IQuizService
    {
        private readonly ApplicationDbContext _context;
        public QuizService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Quiz> GetQuizWithQuestionsAsync(Guid quizId)
        {
            return await _context.Quizzes
                .Include(q => q.Questions)
                    .ThenInclude(q => q.AnswerOptions)
                .FirstOrDefaultAsync(q => q.Id == quizId);
        }
        public int CalculateScore(Quiz quiz, Dictionary<Guid,Guid> submittedAnswers)
        {
            int score = 0;
            foreach (var question in quiz.Questions)
            {
                //Check if user answer the question.
                if (submittedAnswers.TryGetValue(question.Id, out var selectedAnswerId))
                {
                    var correctAnswer = question.AnswerOptions.FirstOrDefault(a => a.isCorrect);
                    if (correctAnswer != null && correctAnswer.Id == selectedAnswerId)
                    {
                        score++;
                    }
                }
            }
            return score;
        }

    }
}
