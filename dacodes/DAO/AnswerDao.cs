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
                Answer founded = dacodesdb.Answer.Find(id);
                if (founded == null)
                {
                    throw new Exception("NotFound");
                }
                dacodesdb.Answer.Remove(founded);
                dacodesdb.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public int Insert(Answer t)
        {
            int result = 0;
            try
            {
                dacodesdb.Answer.Add(t);
                result = dacodesdb.SaveChanges();
            }
            catch
            {
                throw;
            }

            return result;
        }

        public List<Answer> Select(Answer t)
        {
            List<Answer> result = new List<Answer>();
            try
            {
                result = dacodesdb.Answer.ToList();
            }
            catch
            {
                throw;
            }

            return result;
        }

        public Answer Select(int id)
        {
            Answer result = null;
            try
            {
                result = dacodesdb.Answer.Find(id);
            }
            catch
            {
                throw;
            }

            return result;
        }

        public void Update(Answer t)
        {
            try
            {
                dacodesdb.Answer.Update(t);
                dacodesdb.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
