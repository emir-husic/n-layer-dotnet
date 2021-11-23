using System.Collections.Generic;
using Quiz.Common;
using Quiz.Data.Interfaces;
using Quiz.Service.Interfaces;

namespace Quiz.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly IAnswerRepository _answerRepository;

        public AnswerService(IAnswerRepository answerRepository)
        {
            _answerRepository = answerRepository;

        }
        public IEnumerable<Answer> GetAnswers()
        {
            return _answerRepository.GetAnswers();
        }

        public IEnumerable<Answer> GetAnswersToQuestion(int questionId)
        {
            return _answerRepository.GetAnswersOptionsForQuestion(questionId);
        }
    }
}
