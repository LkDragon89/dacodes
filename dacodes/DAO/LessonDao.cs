using dacodes.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dacodes.DAO
{
    public class LessonDao : IDao<Lesson>
    {
        private dacodesdbContext dacodesdb;

        public LessonDao(dacodesdbContext dacodesdb)
        {
            this.dacodesdb = dacodesdb;
        }
        public void Delete(int id)
        {
            try
            {
                var lesson = Select(id);
                dacodesdb.Lesson.Remove(lesson);
                dacodesdb.Entry(lesson).State = EntityState.Deleted;
                dacodesdb.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public int Insert(Lesson t)
        {
            try
            {
                dacodesdb.Lesson.Add(t);
                dacodesdb.Entry(t).State = EntityState.Added;
                dacodesdb.SaveChanges();
                return t.Id;
            }
            catch
            {
                throw;
            }
        }

        public List<Lesson> Select(Lesson t)
        {
            try
            {
                var query = (from dbDacodes in dacodesdb.Lesson
                             select dbDacodes);
                if (!string.IsNullOrEmpty(t.Name))
                    query = query.Where(item => item.Name.Contains(t.Name));
                if (t.IdCorrelative != null)
                    query = query.Where(item => item.IdCorrelative == t.IdCorrelative);
                if (t.Aprovatory != null)
                    query = query.Where(item => item.Aprovatory == t.Aprovatory);
                if (t.IdCourse != null)
                    query = query.Where(item => item.IdCourse == t.IdCourse);
                return query.ToList();
            }
            catch
            {
                throw;
            }
        }

        public Lesson Select(int id)
        {
            try
            {
                return dacodesdb.Lesson.Find(id);
            }
            catch
            {
                throw;
            }
        }

        public void Update(Lesson t)
        {
            try
            {
                dacodesdb.Entry(t).State = EntityState.Modified;
                dacodesdb.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
