using System;
using System.Collections.Generic;

namespace dacodes.Models
{
    public partial class Lesson
    {
        public Lesson()
        {
            Question = new HashSet<Question>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? IdCourse { get; set; }
        public int? IdCorrelative { get; set; }
        public decimal? Aprovatory { get; set; }

        public Course IdCourseNavigation { get; set; }
        public ICollection<Question> Question { get; set; }
    }
}
