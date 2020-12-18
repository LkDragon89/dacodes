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
                
            }
            catch
            {
                throw;
            }
        }
    }
}
