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
                var course = Select(id);
                dacodesdb.Course.Remove(course);
                dacodesdb.Entry(course).State = EntityState.Deleted;
                dacodesdb.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public int Insert(Course t)
        {
            try
            {
                dacodesdb.Course.Add(t);
                dacodesdb.Entry(t).State = EntityState.Added;
                dacodesdb.SaveChanges();
                return t.Id;
            }
            catch
            {
                throw;
            }
        }

        public List<Course> Select(Course t)
        {
            try
            {
                var query = (from dbDacodes in dacodesdb.Course
                             select dbDacodes);
                if (!string.IsNullOrEmpty(t.Name))
                    query = query.Where(item => item.Name.Contains(t.Name));
                if (t.IdCorrelative != null)
                    query = query.Where(item => item.IdCorrelative == t.IdCorrelative);
                return query.ToList();
            }
            catch
            {
                throw;
            }
        }

        public Course Select(int id)
        {
            try
            {
                return dacodesdb.Course.Find(id);
            }
            catch
            {
                throw;
            }
        }

        public void Update(Course t)
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
