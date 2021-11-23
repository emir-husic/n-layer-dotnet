using System.ComponentModel.DataAnnotations.Schema;

namespace Quiz.Common
{
    public class QuestionAnswer
    {
        public int Id { get; set; }

        [Column("question_id")]
        public int QuestionId { get; set; }

        [Column("answer_id")]
        public int AnswerId { get; set; }
    }
}
