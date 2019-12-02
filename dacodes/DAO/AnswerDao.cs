using dacodes.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dacodes.DAO
{
    public class AnswerDao : IDao<Answer>
    {
        private dacodesdbContext dacodesdb;

        public AnswerDao(dacodesdbContext dacodesdb)
        {
            this.dacodesdb = dacodesdb;
        }

        public void Delete(int id)
        {
            try
            {
                var answer = Select(id);
                dacodesdb.Answer.Remove(answer);
                dacodesdb.Entry(answer).State = EntityState.Deleted;
                dacodesdb.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public int Insert(Answer t)
        {
            try
            {
                dacodesdb.Answer.Add(t);
                dacodesdb.Entry(t).State = EntityState.Added;
                dacodesdb.SaveChanges();
                return t.Id;
            }
            catch
            {
                throw;
            }
        }

        public List<Answer> Select(Answer t)
        {
            try
            {
                var query = (from dbDacodes in dacodesdb.Answer
                             select dbDacodes);
                if (t.Idquestion != null)
                    query = query.Where(item => item.Idquestion == t.Idquestion);
                if (string.IsNullOrEmpty(t.Answer1))
                    query = query.Where(item => item.Answer1.Contains(t.Answer1));
                return query.ToList();
            }
            catch
            {
                throw;
            }
        }

        public Answer Select(int id)
        {
            try
            {
                return dacodesdb.Answer.Find(id);
            }
            catch
            {
                throw;
            }
        }

        public void Update(Answer t)
        {
            try
            {
                dacodesdb.Entry(t).State = EntityState.Modified;
                dacodesdb.SaveChanges();
            }
            catch
            {

            }
        }
    }
}
