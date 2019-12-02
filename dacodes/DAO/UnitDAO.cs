using dacodes.Models;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dacodes.DAO
{
    public class UnitDAO
    {
        private IDbContextTransaction dbContextTransacction;
        private dacodesdbContext context;
        private CourseDao courseDao;
        private LessonDao lessonDao;
        private QuestionDao questionDao;
        private AnswerDao answerDao;

        public CourseDao Course { get { return courseDao; } }
        public AnswerDao Answer { get { return answerDao; } }
        public LessonDao Lesson { get { return lessonDao; } }
        public QuestionDao Question { get { return questionDao; } }

        public UnitDAO()
        {
            this.context = new dacodesdbContext();
            this.answerDao = new AnswerDao(context);
            this.courseDao = new CourseDao(context);
            this.lessonDao = new LessonDao(context);
            this.questionDao = new QuestionDao(context);
        }

        public void BeginTran()
        {
            this.dbContextTransacction = context.Database.BeginTransaction();
        }

        public void CommitTran()
        {
            dbContextTransacction.Commit();
        }

        public void RollBackTran()
        {
            dbContextTransacction.Rollback();
        }
    }
}
