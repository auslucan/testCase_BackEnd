using CoursesAPI.Controllers;
using CoursesAPI.Interfaces;
using CoursesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseAPI.Test.UnitTests
{
    public class CourseControllerTest
    {
        [Fact]
        public void WhenGettingAllCourseDetailThenAllCourseDetailsReturn()
        {
            var mockCourseManager = new Mock<ICourseManager>() ;
            var mockCourseDetailManager = new Mock<ICourseDetailManager>();

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
            mockCourseManager.Setup(t => t.FindAll().Result).Returns(() => courses);
            var mockCourseCountroller = new CoursesController(mockCourseManager.Object, mockCourseDetailManager.Object);
            var result = mockCourseCountroller.GetCourses().Result;
            Assert.NotNull(result);
        }
    }
}
