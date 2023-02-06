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
    internal class MockICourseDetailRepository
    {
        public static Mock<ICourseDetailRepository> GetMock()
        {
            var mock = new Mock<ICourseDetailRepository>();
            var courses = new List<CourseDetail>()
        {
            new CourseDetail()
            {
                Id = Guid.Parse("0f8fad5b-d9cb-469f-a165-70867728950e"),
                CourseDescription="test",
                CourseId=Guid.Parse("0f8fad5b-d9cb-469f-a165-70867725678e"),
                CourseName="test",
                CourseUrlPath   ="urlpath"
            }
        };
            mock.Setup(m => m.GetAllCourseDetailsAsync().Result).Returns(() => courses);
            mock.Setup(m => m.GetCourseDetailByIdAsync(It.IsAny<Guid>()).Result)
                .Returns((Guid id) => courses.FirstOrDefault(o => o.Id == id));
          
            mock.Setup(m => m.CreateCourseDetail(It.IsAny<CourseDetail>()))
                .Callback(() => { return; });
            mock.Setup(m => m.UpdateCourseDetail(It.IsAny<CourseDetail>()))
               .Callback(() => { return; });
            mock.Setup(m => m.DeleteCourseDetail(It.IsAny<CourseDetail>()))
               .Callback(() => { return; });
            return mock;
        }
    }
}
