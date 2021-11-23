using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quiz.Common
{
    public class Question
    {

        public int Id { get; set; }

        [Column("category_id")]
        public int CategoryId { get; set; }

        [Column("question")]
        public String Text { get; set; }

        [Column("image_url")]
        public String ImageUrl { get; set; }

        public String Explanation { get; set; }

        public int CorrectAnswerId { get; set; }

        public IEnumerable<Answer> Answers { get; set; }
    }
}
