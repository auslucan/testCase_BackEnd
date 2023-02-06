using CoursesAPI.Data.Interfaces;
using CoursesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CoursesAPI.Data.Repositories
{
    public class CourseDetailRepository : RepositoryBase<CourseDetail>, ICourseDetailRepository
    {
        public CourseDetailRepository(CourseContext courseContext) : base(courseContext)
        {

        }
        public async Task<IEnumerable<CourseDetail>> GetAllCourseDetailsAsync()
        {
            return await FindAll()
               .OrderBy(co => co.Id)
               .ToListAsync();
        }
        public async Task<CourseDetail> GetCourseDetailByIdAsync(Guid courseId)
        {
            return await FindByCondition(course => course.Id.Equals(courseId))
                .FirstOrDefaultAsync();
        }
        public async Task<List<CourseDetail>> GetAllCourseDetailsByIdAsync(Guid courseId)
        {
            return await FindByCondition(course => course.CourseId == courseId)
                .ToListAsync();
        }

        public void CreateCourseDetail(CourseDetail course)
        {
            Create(course);
        }
        public void UpdateCourseDetail(CourseDetail course)
        {
            Update(course);
        }
        public void DeleteCourseDetail(CourseDetail course)
        {
            Delete(course);
        }
    }
}
