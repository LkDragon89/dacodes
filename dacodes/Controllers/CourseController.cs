using dacodes.Query;
using dacodes.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace dacodes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private CourseService service;

        public CourseController()
        {
            service = new CourseService();
        }
        [HttpGet]
        public ActionResult<List<CourseQ>> Get(CourseQ course)
        {
            try
            {
                var response = service.Get(course);
                if (response == null)
                    return NotFound();
                return response;
            } catch (Exception e) {
                return Content(e.Message);
            }
        }

        [HttpPost]
        public ActionResult Post(CourseQ course)
        {
            try
            {
                var id = service.Save(course);
                return CreatedAtAction(nameof(Get), new { Id = id }, new CourseQ());
            }
            catch(Exception e)
            {
                return Content(e.Message);
            }
        }

        [HttpPut]
        public ActionResult Put(CourseQ course)
        {
            try
            {
                service.Edit(course);
                return NoContent();
            }
            catch(Exception e)
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
            catch(Exception e)
            {
                return Content(e.Message);
            }
        }

        [HttpGet("{Id}")]
        public ActionResult<CourseQ> Get(int Id)
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