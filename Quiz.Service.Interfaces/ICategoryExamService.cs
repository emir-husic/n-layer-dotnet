using System.Collections.Generic;
using Quiz.Common;

namespace Quiz.Service.Interfaces
{
    public interface ICategoryExamService
    {
        public IEnumerable<CategoryExam> GetCategoryExam(int categoryId);
    }
}
