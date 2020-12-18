using dacodes.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dacodes.DAO
{
    public class CourseDao : IDao<Course>
    {
        private dacodesdbContext dacodesdb;

        public CourseDao(dacodesdbContext dacodesdb)
        {
            this.dacodesdb = dacodesdb;
        }
        public void Delete(int id)
        {
            try
            {
                Course founded = dacodesdb.Course.Find(id);
                if (founded == null)
                {
                    throw new Exception("NotFound");
                }
                dacodesdb.Course.Remove(founded);
                dacodesdb.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public int Insert(Course t)
        {
            int result = 0;
            try
            {
                dacodesdb.Course.Add(t);
                result = dacodesdb.SaveChanges();
            }
            catch
            {
                throw;
            }

            return result;
        }

        public List<Course> Select(Course t)
        {
            List<Course> result = new List<Course>();
            try
            {
                result = dacodesdb.Course.ToList();
            }
            catch
            {
                throw;
            }

            return result;
        }

        public Course Select(int id)
        {
            Course result = null;
            try
            {
                result = dacodesdb.Course.Find(id);
            }
            catch
            {
                throw;
            }

            return result;
        }

        public void Update(Course t)
        {
            try
            {
                dacodesdb.Course.Update(t);
                dacodesdb.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
