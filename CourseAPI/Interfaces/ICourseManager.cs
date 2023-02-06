using CoursesAPI.Data.Repositories;
using CoursesAPI.Models;

namespace CoursesAPI.Interfaces
{
    public interface ICourseManager
    {
        public  Task<List<Course>> FindAll();
        Task<List<Course>> FindAllById(Guid id);
        public  Task<Course> Find(Guid id);
        public void CreateCourse(Course course);
        public void UpdateCourse(Course course); 
        public void DeleteCourse(Course course);
       public  Task SaveCourse();
    }
}
