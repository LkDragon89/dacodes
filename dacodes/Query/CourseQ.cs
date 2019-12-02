using System.Collections.Generic;

namespace dacodes.Query
{
    public class CourseQ
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public CourseQ CorrelativeCourse { get; set; }

        public List<LessonQ> Lessons { get; set; }
    }
}
