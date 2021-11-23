using System;
using System.Collections.Generic;
using Quiz.Common;

namespace Quiz.Data.Interfaces
{
    public interface IQuestionRepository
    {
        public IEnumerable<Question> GetQuestions();
        public IEnumerable<Question> GetCategoryQuestions(int categoryId);
    }
}
