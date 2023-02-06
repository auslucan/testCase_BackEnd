using CoursesAPI.Data.Repositories;
using CoursesAPI.Models;

namespace CoursesAPI.Data.Interfaces
{
    public interface ICourseRepository: IRepositoryBase<Course>
    {
        Task<List<Course>> GetAllCoursesAsync();
        Task<List<Course>> GetAllCoursesByIdAsync(Guid courseId);
        Task<Course> GetCourseByIdAsync(Guid courseId); 
        //Task<Course> GetCourseWithDetailsAsync(Guid courseId);
        void CreateCourse(Course course);
        void UpdateCourse(Course course);
        void DeleteCourse(Course course);
    }
}
