using CoursesAPI.Models;

namespace CoursesAPI.Interfaces
{
    public interface ICourseDetailManager
    {
        public Task<IEnumerable<CourseDetail>> FindAll();
        Task<List<CourseDetail>> FindAllById(Guid id);
        public Task<CourseDetail> Find(Guid id);
        public void CreateCourseDetail(CourseDetail course);
        public void UpdateCourseDetail(CourseDetail course);
        public void DeleteCourseDetail(CourseDetail course);
        public Task SaveCourseDetail();

    }
}
