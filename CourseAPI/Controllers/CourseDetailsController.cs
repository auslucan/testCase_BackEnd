using Microsoft.AspNetCore.Mvc;
using CoursesAPI.Models;
using CoursesAPI.Interfaces;

namespace CourseDetailsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseDetailsController : ControllerBase
    {
        private readonly ICourseDetailManager CourseDetailManager;
        private readonly ICourseManager CourseManager;

        public CourseDetailsController(ICourseDetailManager courseDetailManager, ICourseManager courseManager)
        {
            CourseDetailManager = courseDetailManager;
            CourseManager = courseManager;
        }

        [HttpPost]
        public async Task<ActionResult<CourseDetail>> AddCourseDetailAsync(CourseDetail CourseDetail)
        {
            CourseDetailManager.CreateCourseDetail(CourseDetail);
            var course =await CourseManager.Find(CourseDetail.CourseId);
            course.Status = true;
            CourseManager.UpdateCourse(course);
            await CourseDetailManager.SaveCourseDetail();
            return CourseDetail;
        }

        //GET : api/CourseDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseDetail>>> GetCourseDetails()
        {
            var result = await CourseDetailManager.FindAll();
            if (result == null) return NotFound();
            return result.ToList();
        }

        //GET : api/CourseDetails/id
        [HttpGet("{id}")]
        public async Task<ActionResult<List<CourseDetail>>> GetCourseDetails(Guid id)
        {
            var result = await CourseDetailManager.FindAllById(id);
            if (result == null) return NotFound();
            return result;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CourseDetail>> UpdateCourseDetail(Guid id, CourseDetail CourseDetail)
        {
            var result = await CourseDetailManager.Find(id);
            if (result == null) return BadRequest();

            CourseDetailManager.UpdateCourseDetail(CourseDetail);
             await CourseDetailManager.SaveCourseDetail();
            return result;


        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourseDetail(Guid id)
        {

            var result = await CourseDetailManager.Find(id);
            if (result == null) return NotFound();

            CourseDetailManager.DeleteCourseDetail(result);
            await CourseDetailManager.SaveCourseDetail();
            return NoContent();

        }
    }
}
