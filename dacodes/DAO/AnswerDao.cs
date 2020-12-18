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
                
            }
            catch
            {

            }
        }
    }
}
