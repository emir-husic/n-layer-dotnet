using System.Collections.Generic;

namespace Quiz.Common
{
    public class CategoryExam
    {

        public int Id { get; set; }

        public int CategoryId { get; set; }

        public string Text { get; set; }

        public string ImageUrl { get; set; }

        public string Explanation { get; set; }

        public int CorrectAnswerId { get; set; }

        public IEnumerable<Answer> Answers { get; set; }
  
    }
}
