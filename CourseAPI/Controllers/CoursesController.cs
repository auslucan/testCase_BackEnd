using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoursesAPI.Models;
using CoursesAPI.Data.Interfaces;
using CoursesAPI.Interfaces;
using CoursesAPI.Managers;

namespace CoursesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseManager CourseManager;
        private readonly ICourseDetailManager CourseDetailManager;

        public CoursesController(ICourseManager courseManager, ICourseDetailManager courseDetailManager)
        {
            CourseManager = courseManager;
            CourseDetailManager = courseDetailManager;
        }

        [HttpPost]
        public async Task<ActionResult<Course>> AddCourseAsync(Course course)
        {
            CourseManager.CreateCourse(course);
            await CourseManager.SaveCourse();
            return course;
        }

        //GET : api/courses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
        {
            var result = await CourseManager.FindAll();
            if (result == null) return NotFound();
            return result.ToList();
        }

        //GET : api/courses/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourses(Guid id)
        {
            var result = await CourseManager.Find(id);
            if (result == null) return NotFound();
            return result;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Course>> UpdateCourse(Guid id, Course course)
        {
            var result = await CourseManager.Find(id);
            if (result == null) return BadRequest();

            CourseManager.UpdateCourse(course);
            await CourseManager.SaveCourse();

            return result;


        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(Guid id)
        {

            var result = await CourseManager.Find(id);
            if (result == null) return NotFound();
            var courseDetails = await CourseDetailManager.FindAllById(id);
            foreach (var item in courseDetails)
            {
                CourseDetailManager.DeleteCourseDetail(item);
            }
            CourseManager.DeleteCourse(result);
            await CourseManager.SaveCourse();

            return NoContent();

        }
    }
}
