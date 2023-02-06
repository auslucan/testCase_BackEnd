using CoursesAPI.Data.Interfaces;
using CoursesAPI.Interfaces;
using CoursesAPI.Models;

namespace CoursesAPI.Managers
{
    public class CourseManager: ICourseManager
    {
        private readonly IRepositoryWrapper RepositoryWrapper;
        public CourseManager(IRepositoryWrapper repositoryWrapper)
        {
            RepositoryWrapper = repositoryWrapper ?? throw new ArgumentNullException(nameof(RepositoryWrapper)); ;
        }
        public async Task<List<Course>> FindAll()
        {
           return await RepositoryWrapper.CourseRepository.GetAllCoursesAsync();
        }
        public async Task<List<Course>> FindAllById(Guid id)
        {
            return await RepositoryWrapper.CourseRepository.GetAllCoursesByIdAsync(id);
        }
        public async Task<Course> Find(Guid id)
        {
            return await RepositoryWrapper.CourseRepository.GetCourseByIdAsync(id);
        }
        public void CreateCourse(Course course)
        {
            RepositoryWrapper.CourseRepository.CreateCourse(course);
        }
        public void UpdateCourse(Course course)
        {
            RepositoryWrapper.CourseRepository.UpdateCourse(course);
        }
        public void DeleteCourse(Course course)
        {
            RepositoryWrapper.CourseRepository.DeleteCourse(course);
        }
        public async Task SaveCourse()
        {
           await RepositoryWrapper.SaveAsync();
        }
    }
}
