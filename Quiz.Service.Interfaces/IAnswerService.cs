using System.Collections.Generic;
using Quiz.Common;
namespace Quiz.Service.Interfaces
{
    public interface IAnswerService
    {
        public IEnumerable<Answer> GetAnswers();
        public IEnumerable<Answer> GetAnswersToQuestion(int questionId);
    }
}
