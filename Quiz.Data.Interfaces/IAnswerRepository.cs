using System.Collections.Generic;
using Quiz.Common;

namespace Quiz.Data.Interfaces
{
    public interface IAnswerRepository
    {
        public IEnumerable<Answer> GetAnswers();
        public IEnumerable<Answer> GetAnswersOptionsForQuestion(int questionId);
    }
}
