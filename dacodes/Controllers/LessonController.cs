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
    public class LessonController : ControllerBase
    {
        private LessonService service;

        public LessonController()
        {
            service = new LessonService();
        }
        [HttpGet]
        public ActionResult<List<LessonQ>> Get(LessonQ lesson)
        {
            try
            {
                var response = service.Get(lesson);
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
        public ActionResult Post(LessonQ lesson)
        {
            try
            {
                var id = service.Save(lesson);
                return CreatedAtAction(nameof(Get), new { Id = id }, new CourseQ());
            }
            catch (Exception e)
            {
                return Content(e.Message);
            }
        }

        [HttpPut]
        public ActionResult Put(LessonQ lesson)
        {
            try
            {
                service.Edit(lesson);
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
        public ActionResult<LessonQ> Get(int Id)
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