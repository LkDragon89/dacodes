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
                
            }
            catch
            {
                throw;
            }
        }
    }
}
