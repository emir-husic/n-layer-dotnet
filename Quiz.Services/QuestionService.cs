using System;
using System.Collections.Generic;
using Quiz.Common;
using Quiz.Data.Interfaces;
using Quiz.Service.Interfaces;

namespace Quiz.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionService(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public IEnumerable<Question> GetAllQuestions()
        {
            return _questionRepository.GetQuestions();
        }

        public IEnumerable<Question> GetCategoryQuestions(int categoryId)
        {
            return _questionRepository.GetCategoryQuestions(categoryId);
        }
    }
}
