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
                var question = Select(id);
                dacodesdb.Question.Remove(question);
                dacodesdb.Entry(question).State = EntityState.Deleted;
                dacodesdb.SaveChanges();
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
                dacodesdb.Question.Add(t);
                dacodesdb.SaveChanges();
                return t.Id;
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
                var questionQuery = (from dbDacodes in dacodesdb.Question
                                     select dbDacodes);

                if (!string.IsNullOrEmpty(t.Question1))
                    questionQuery = questionQuery.Where(item => item.Question1.Contains(t.Question1));
                if (t.Idlesson != null)
                    questionQuery = questionQuery.Where(item => item.Idlesson == t.Idlesson);
                return questionQuery.ToList();
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
