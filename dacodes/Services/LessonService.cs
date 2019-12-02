using dacodes.DAO;
using dacodes.Models;
using dacodes.Query;
using dacodes.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dacodes.Services
{
    public class LessonService : IService<LessonQ>
    {
        private UnitDAO unitDao;
        private IService<QuestionQ> service;

        public LessonService()
        {
            unitDao = new UnitDAO();
            service = new QuestionService();
        }

        public void Delete(int id)
        {
            unitDao.BeginTran();
            try
            {
                unitDao.Lesson.Delete(id);
                unitDao.CommitTran();
            }
            catch
            {
                unitDao.RollBackTran();
                throw;
            }
        }

        public void Edit(LessonQ lesson)
        {
            try
            {
                if (unitDao.Lesson.Select((int)lesson.Id) != null)
                    return;

                var model = new Validate<Lesson>().CopyToModel(lesson);
                unitDao.Lesson.Update(model);
            }
            catch
            {
                throw;
            }
        }

        public bool Exist(LessonQ lesson)
        {
            throw new NotImplementedException();
        }

        public LessonQ Get(int id)
        {
            try
            {
                var model = unitDao.Lesson.Select(id);
                return new Validate<LessonQ>().CopyToModel(model);
            }
            catch
            {
                throw;
            }
        }

        public List<LessonQ> Get(LessonQ lesson)
        {
            try
            {
                List<LessonQ> lessons = new List<LessonQ>();
                var model = new Validate<Lesson>().CopyToModel(lesson);
                var models = unitDao.Lesson.Select(model);
                models.ForEach(item => lessons.Add(new Validate<LessonQ>().CopyToModel(item)));
                return lessons;
            }
            catch
            {
                return null;
            }
        }

        public LessonQ Save(LessonQ lesson)
        {
            try
            {
                var model = new Validate<Lesson>().CopyToModel(lesson);
                var id = unitDao.Lesson.Insert(model);
                lesson.Id = id;

                if(lesson.Questions == null)
                {
                    return lesson;
                }

                lesson.Questions.ForEach(question =>
                {
                    question.IdLesson = id;
                    question = service.Save(question);
                });
                return lesson;
            }
            catch
            {
                throw;
            }
        }
    }
}
