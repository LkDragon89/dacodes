using System.Collections.Generic;

namespace dacodes.Query
{
    public class QuestionQ
    {
        public int? Id { get; set; }

        public string Description { get; set; }

        public decimal Value { get; set; }

        public List<AnswerQ> Answers { get; set; }

        public int IdLesson { get; set; }
    }
}
