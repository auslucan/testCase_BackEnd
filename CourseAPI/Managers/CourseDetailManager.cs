using CoursesAPI.Data.Interfaces;
using CoursesAPI.Interfaces;
using CoursesAPI.Models;

namespace CoursesAPI.Managers
{
    public class CourseDetailManager : ICourseDetailManager
    {
        private readonly IRepositoryWrapper RepositoryWrapper;
        public CourseDetailManager(IRepositoryWrapper repositoryWrapper)
        {
            RepositoryWrapper = repositoryWrapper ?? throw new ArgumentNullException(nameof(repositoryWrapper)); ;
        }
        public async Task<IEnumerable<CourseDetail>> FindAll()
        {
            return await RepositoryWrapper.CourseDetailRepository.GetAllCourseDetailsAsync();
        }
        public async Task<List<CourseDetail>> FindAllById(Guid id)
        {
            return await RepositoryWrapper.CourseDetailRepository.GetAllCourseDetailsByIdAsync(id);
        }
        public async Task<CourseDetail> Find(Guid id)
        {
            return await RepositoryWrapper.CourseDetailRepository.GetCourseDetailByIdAsync(id);
        }
        public void CreateCourseDetail(CourseDetail course)
        {
            RepositoryWrapper.CourseDetailRepository.CreateCourseDetail(course);
        }
        public void UpdateCourseDetail(CourseDetail course)
        {
            RepositoryWrapper.CourseDetailRepository.UpdateCourseDetail(course);
        }
        public void DeleteCourseDetail(CourseDetail course)
        {
            RepositoryWrapper.CourseDetailRepository.DeleteCourseDetail(course);
        }
        public async Task SaveCourseDetail()
        {
            await RepositoryWrapper.SaveAsync();
        }
    }
}
