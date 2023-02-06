using CoursesAPI.Models;

namespace CoursesAPI.Data.Interfaces
{
    public interface ICourseDetailRepository: IRepositoryBase<CourseDetail>
    {
        Task<IEnumerable<CourseDetail>> GetAllCourseDetailsAsync();
        Task<List<CourseDetail>> GetAllCourseDetailsByIdAsync(Guid courseId);
        Task<CourseDetail> GetCourseDetailByIdAsync(Guid courseId);
        //Task<Course> GetCourseWithDetailsAsync(Guid courseId);
        void CreateCourseDetail(CourseDetail course);
        void UpdateCourseDetail(CourseDetail course);
        void DeleteCourseDetail(CourseDetail course);
    }
}
