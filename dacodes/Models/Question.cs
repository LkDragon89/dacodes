using System;
using System.Collections.Generic;

namespace dacodes.Models
{
    public partial class Question
    {
        public Question()
        {
            Answer = new HashSet<Answer>();
        }

        public int Id { get; set; }
        public string Question1 { get; set; }
        public int? Idlesson { get; set; }
        public decimal Value { get; set; }

        public Lesson IdlessonNavigation { get; set; }
        public ICollection<Answer> Answer { get; set; }
    }
}
