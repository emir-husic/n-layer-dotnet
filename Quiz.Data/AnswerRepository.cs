using System.Collections.Generic;
using Quiz.Common;
using Quiz.Data.Interfaces;
using System.Linq;
namespace Quiz.Data
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly QuizContext _context;
        public AnswerRepository(QuizContext context)
        {
            _context = context;
        }

        public IEnumerable<Answer> GetAnswers()
        {
            return _context.Answers;
        }

        public IEnumerable<Answer> GetAnswersOptionsForQuestion(int questionId)
        {
            return _context.Answers.Where(x => x.QuestionId == questionId).ToList();
        }
    }
}
