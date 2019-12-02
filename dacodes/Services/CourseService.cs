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
    public class CourseService : IService<CourseQ>
    {
        private UnitDAO unitDao;
        private IService<LessonQ> service;

        public CourseService()
        {
            unitDao = new UnitDAO();
            service = new LessonService();
        }
        public void Delete(int id)
        {
            unitDao.BeginTran();
            try
            {
                unitDao.Question.Delete(id);
                unitDao.CommitTran();
            }
            catch
            {
                unitDao.RollBackTran();
                throw;
            }
        }

        public void Edit(CourseQ course)
        {
            unitDao.BeginTran();
            try
            {
                if(unitDao.Course.Select((int)course.Id) != null)
                {
                    return;
                }

                //Se realiza la actualizacion
                var model = new Validate<Course>().CopyToModel(course); 
                unitDao.Course.Update(model);
                unitDao.CommitTran();
            }
            catch
            {
                unitDao.RollBackTran();
                throw;
            }
        }

        public bool Exist(CourseQ t)
        {
            throw new NotImplementedException();
        }

        public CourseQ Get(int id)
        {
            try
            {
                var model = unitDao.Course.Select(id);
                return new Validate<CourseQ>().CopyToModel(model);
            }
            catch
            {
                throw;
            }
        }

        public List<CourseQ> Get(CourseQ course)
        {
            try
            {
                List<CourseQ> courses = new List<CourseQ>();
                var model = new Validate<Course>().CopyToModel(course);
                var models = unitDao.Course.Select(model);
                foreach(var aux in models)
                {
                    courses.Add(new Validate<CourseQ>().CopyToModel(aux));
                }
                return courses;
            }
            catch
            {
                throw;
            }
        }

        public CourseQ Save(CourseQ course)
        {
            unitDao.BeginTran();
            try
            {
                var model = new Validate<Course>().CopyToModel(course);
                var id = unitDao.Course.Insert(model);
                course.Id = id;
                if(course.Lessons == null)
                {
                    unitDao.CommitTran();
                    return course;
                }

                course.Lessons.ForEach(lesson =>
                {
                    lesson.IdCourse = id;
                    lesson = service.Save(lesson);
                });

                unitDao.CommitTran();
                return course;
            }
            catch(Exception e)
            {
                unitDao.RollBackTran();
                throw;
            }
            
        }
    }
}
