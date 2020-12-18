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
                Question founded = dacodesdb.Question.Find(id);
                if (founded == null)
                {
                    throw new Exception("NotFound");
                }
                dacodesdb.Question.Remove(founded);
                dacodesdb.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public int Insert(Question t)
        {
            int result = 0;
            try
            {
                dacodesdb.Question.Add(t);
                result = dacodesdb.SaveChanges();
            }
            catch
            {
                throw;
            }

            return result;
        }

        public List<Question> Select(Question t)
        {
            List<Question> result = new List<Question>();
            try
            {
                result = dacodesdb.Question.ToList();
            }
            catch
            {
                throw;
            }

            return result;
        }

        public Question Select(int id)
        {
            Question result = null;
            try
            {
                result = dacodesdb.Question.Find(id);
            }
            catch
            {
                throw;
            }

            return result;
        }

        public void Update(Question t)
        {
            try
            {
                dacodesdb.Question.Update(t);
                dacodesdb.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
