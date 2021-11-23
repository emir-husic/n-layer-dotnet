using System.Collections.Generic;
using Quiz.Common;

namespace Quiz.Service.Interfaces
{
    public interface IQuestionService
    {
        public IEnumerable<Question> GetAllQuestions();
        public IEnumerable<Question> GetCategoryQuestions(int id);
    }
}
