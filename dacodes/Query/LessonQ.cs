using System.Collections.Generic;

namespace dacodes.Query
{
    public class LessonQ
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public LessonQ CorrelativeLesson { get; set; }

        public List<QuestionQ> Questions { get; set; }

        public decimal Approvatory { get; set; }

        public int? IdCourse { get; set; }

    }
}
