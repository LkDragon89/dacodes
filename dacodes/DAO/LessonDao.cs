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
                Lesson founded = dacodesdb.Lesson.Find(id);
                if (founded == null)
                {
                    throw new Exception("NotFound");
                }
                dacodesdb.Lesson.Remove(founded);
                dacodesdb.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public int Insert(Lesson t)
        {
            int result = 0;
            try
            {
                dacodesdb.Lesson.Add(t);
                result = dacodesdb.SaveChanges();
            }
            catch
            {
                throw;
            }

            return result;
        }

        public List<Lesson> Select(Lesson t)
        {
            List<Lesson> result = new List<Lesson>();
            try
            {
                result = dacodesdb.Lesson.ToList();
            }
            catch
            {
                throw;
            }

            return result;
        }

        public Lesson Select(int id)
        {
            Lesson result = null;
            try
            {
                result = dacodesdb.Lesson.Find(id);
            }
            catch
            {
                throw;
            }

            return result;
        }

        public void Update(Lesson t)
        {
            try
            {
                dacodesdb.Lesson.Update(t);
                dacodesdb.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
