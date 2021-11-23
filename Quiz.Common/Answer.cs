using System.ComponentModel.DataAnnotations.Schema;

namespace Quiz.Common
{
    public class Answer
    {
        public int Id { get; set; }

        [Column("question_id")]
        public int QuestionId { get; set; }

        [Column("answer")]
        public string Text { get; set; }

        [NotMapped]
        public bool Correct { get; set; }
    }
}
