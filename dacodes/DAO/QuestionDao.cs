using dacodes.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dacodes.DAO
{
    public class QuestionDao : IDao<Question>
    {
        private dacodesdbContext dacodesdb;

        public QuestionDao(dacodesdbContext dacodesdb)
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

        public int Insert(Question t)
        {
            try
            {
                
            }
            catch
            {
                throw;
            }
        }

        public List<Question> Select(Question t)
        {
            try
            {
               
            }
            catch
            {
                throw;
            }
        }

        public Question Select(int id)
        {
            try
            {
                return dacodesdb.Question.Find(id);
            }
            catch
            {
                throw;
            }
        }

        public void Update(Question t)
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
