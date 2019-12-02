using System;
using System.Collections.Generic;

namespace dacodes.Models
{
    public partial class Course
    {
        public Course()
        {
            Lesson = new HashSet<Lesson>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? IdCorrelative { get; set; }

        public ICollection<Lesson> Lesson { get; set; }
    }
}
