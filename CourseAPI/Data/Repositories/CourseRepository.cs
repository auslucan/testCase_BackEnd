using CoursesAPI.Data.Interfaces;
using CoursesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CoursesAPI.Data.Repositories
{
    public class CourseRepository : RepositoryBase<Course>, ICourseRepository
    {
        public CourseRepository(CourseContext repositoryContext)
       : base(repositoryContext)
        {
        }
        public async Task<List<Course>> GetAllCoursesAsync()
        {
            return await FindAll()
               .OrderBy(co => co.Id)
               .ToListAsync();
        }
        public async Task<Course> GetCourseByIdAsync(Guid courseId)
        {
            return await FindByCondition(course => course.Id.Equals(courseId))
                .FirstOrDefaultAsync();
        }
        public async Task<List<Course>> GetAllCoursesByIdAsync(Guid courseId)
        {
            return await FindByCondition(course => course.Id.Equals(courseId))
                .ToListAsync();
        }
        
        public void CreateCourse(Course course)
        {
            Create(course);
        }
        public void UpdateCourse(Course course)
        {
            Update(course);
        }
        public void DeleteCourse(Course course)
        {
            Delete(course);
        }
    }
}
