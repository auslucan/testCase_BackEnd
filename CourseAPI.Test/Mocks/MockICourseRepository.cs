using CoursesAPI.Data.Interfaces;
using CoursesAPI.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CourseAPI.Test.Mocks
{
    internal class MockICourseRepository
    {
        public static Mock<ICourseRepository> GetMock()
        {
            var mock = new Mock<ICourseRepository>();
            var courses = new List<Course>()
        {
            new Course()
            {
                Id = Guid.Parse("0f8fad5b-d9cb-469f-a165-70867728950e"),
                Name = "John",
                StartDate=DateTime.UtcNow.ToString(),
                EndDate=DateTime.UtcNow.ToString(),
                Status=true
            }
        };
            mock.Setup(m => m.GetAllCoursesAsync().Result).Returns(() => courses);
            mock.Setup(m => m.GetCourseByIdAsync(It.IsAny<Guid>()).Result)
                .Returns((Guid id) => courses.FirstOrDefault(o => o.Id == id));
          
            mock.Setup(m => m.CreateCourse(It.IsAny<Course>()))
                .Callback(() => { return; });
            mock.Setup(m => m.UpdateCourse(It.IsAny<Course>()))
               .Callback(() => { return; });
            mock.Setup(m => m.DeleteCourse(It.IsAny<Course>()))
               .Callback(() => { return; });
            return mock;
        }
    }
}
