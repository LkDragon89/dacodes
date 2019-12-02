using dacodes.DAO;
using dacodes.Models;
using dacodes.Query;
using dacodes.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dacodes.Services
{
    public class QuestionService : IService<QuestionQ>
    {
        private UnitDAO unitDao;

        public QuestionService()
        {
            unitDao = new UnitDAO();
        }
        public void Delete(int id)
        {
            unitDao.BeginTran();
            try
            {
                unitDao.Question.Delete(id);
                unitDao.CommitTran();
            }
            catch
            {
                unitDao.RollBackTran();
                throw;
            }
        }

        public void Edit(QuestionQ query)
        {
            unitDao.BeginTran();
            try
            {
                var question = new Validate<Question>().CopyToModel(query);
                unitDao.Question.Update(question);
                query.Answers.ForEach(answer => EditAnswer(answer));
                unitDao.CommitTran();
            }
            catch
            {
                unitDao.RollBackTran();
                throw;
            }
        }

        public bool Exist(QuestionQ t)
        {
            throw new NotImplementedException();
        }

        public QuestionQ Get(int id)
        {
            try
            {
                var question = unitDao.Question.Select(id);
                var response = new Validate<QuestionQ>().CopyToModel(question);
                return response;
            }
            catch
            {
                throw;
            }
        }

        public List<QuestionQ> Get(QuestionQ query)
        {
            try
            {
                List<QuestionQ> questions = new List<QuestionQ>();
                var question = new Validate<Question>().CopyToModel(query);
                var lQuestionModel = unitDao.Question.Select(question);

                foreach(var auxQuestion in lQuestionModel)
                {
                    questions.Add(new Validate<QuestionQ>().CopyToModel(auxQuestion));
                }

                return questions;
                
            }
            catch
            {
                throw;
            }
        }

        public QuestionQ Save(QuestionQ query)
        {
            try
            {
                if (query.Answers != null)
                    return null;
                var question = new Validate<Question>().CopyToModel(query);
                var id = unitDao.Question.Insert(question);

                query.Answers.ForEach(answer => answer.IdQuestion = id);
                query.Answers.ForEach(answer => SaveAnswer(answer));
                return query;
            }
            catch
            {
                throw;
            }
            
        }

        private void SaveAnswer(AnswerQ answer)
        {
            try
            {
                var answer1 = new Validate<Answer>().CopyToModel(answer);
                unitDao.Answer.Insert(answer1);
            }
            catch
            {
                throw;
            }
        }

        private void EditAnswer(AnswerQ answerQ)
        {
            try
            {
                var answer = new Validate<Answer>().CopyToModel(answerQ);
                unitDao.Answer.Update(answer);
            }
            catch
            {
                throw;
            }
        }
    }
}
