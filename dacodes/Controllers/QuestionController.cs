using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dacodes.Query;
using dacodes.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dacodes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private QuestionService service;

        public QuestionController()
        {
            service = new QuestionService();
        }
        [HttpGet]
        public ActionResult<List<QuestionQ>> Get(QuestionQ question)
        {
            try
            {
                var response = service.Get(question);
                if (response == null)
                    return NotFound();
                return response;
            }
            catch (Exception e)
            {
                return Content(e.Message);
            }
        }

        [HttpPost]
        public ActionResult Post(QuestionQ question)
        {
            try
            {
                var id = service.Save(question);
                return CreatedAtAction(nameof(Get), new { Id = id }, new CourseQ());
            }
            catch (Exception e)
            {
                return Content(e.Message);
            }
        }

        [HttpPut]
        public ActionResult Put(QuestionQ question)
        {
            try
            {
                service.Edit(question);
                return NoContent();
            }
            catch (Exception e)
            {
                return Content(e.Message);
            }
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                service.Delete(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return Content(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<QuestionQ> Get(int Id)
        {
            try
            {
                return service.Get(Id);
            }
            catch (Exception e)
            {
                return Content(e.Message);
            }
        }
    }
}