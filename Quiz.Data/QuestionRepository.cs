using System.Collections.Generic;
using Quiz.Common;
using Quiz.Data.Interfaces;
using System.Linq;
namespace Quiz.Data
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly QuizContext _context;
        public QuestionRepository(QuizContext context)
        {
            _context = context;
        }

        public IEnumerable<Question> GetCategoryQuestions(int categoryId)
        {
            var data = _context.Questions.Join(_context.QuestionAnswer,
    question => question.Id,
    answer => answer.QuestionId,
    (question, answer) => new Question
    {
        Id = question.Id,
        Text = question.Text,
        ImageUrl = question.ImageUrl,
        CategoryId = question.CategoryId,
        CorrectAnswerId = answer.AnswerId
    }
        ).Join(_context.QuestionExplanations,
        question => question.Id,
        explanation => explanation.QuestionId,
        (question, explanation) => new Question
        {
            Id = question.Id,
            Text = question.Text,
            ImageUrl = question.ImageUrl,
            CategoryId = question.CategoryId,
            CorrectAnswerId = question.CorrectAnswerId,
            Explanation = explanation.Explanation
        }).Where(x => x.CategoryId == categoryId).ToList();
            return data;
        }

        public IEnumerable<Question> GetQuestions()
        {
            var data = _context.Questions.Join(_context.QuestionAnswer,
                question => question.Id,
                answer => answer.QuestionId,
                (question, answer) => new Question
                {
                    Id = question.Id,
                    Text = question.Text,
                    ImageUrl = question.ImageUrl,
                    CategoryId = question.CategoryId,
                    CorrectAnswerId = answer.AnswerId
                }
                    ).Join(_context.QuestionExplanations,
                    question => question.Id,
                    explanation => explanation.QuestionId,
                    (question, explanation) => new Question
                    {
                        Id = question.Id,
                        Text = question.Text,
                        ImageUrl = question.ImageUrl,
                        CategoryId = question.CategoryId,
                        CorrectAnswerId = question.CorrectAnswerId,
                        Explanation = explanation.Explanation
                    }).ToList();
            return data;
        }
    }
}
