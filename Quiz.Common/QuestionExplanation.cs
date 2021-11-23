using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quiz.Common
{
    public class QuestionExplanation
    {
        public int Id { get; set; }
        [Column("question_id")]
        public int QuestionId { get; set; }
        public string Explanation { get; set; }
    }
}
