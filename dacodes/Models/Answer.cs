using System;
using System.Collections.Generic;

namespace dacodes.Models
{
    public partial class Answer
    {
        public int Id { get; set; }
        public int? Idquestion { get; set; }
        public string Answer1 { get; set; }
        public bool IsCorrect { get; set; }

        public Question IdquestionNavigation { get; set; }
    }
}
