using CourseAPI.Test.Mocks;
using CoursesAPI.Controllers;
using CoursesAPI.Managers;
using CoursesAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseAPI.Test.UnitTests
{
    public class CourseDetailManagerTest
    {
        [Fact]
        public  void WhenGettingAllCourseDetailThenAllCourseDetailsReturn()
        {
            var repositoryWrapperMock = MockIRepositoryWrapper.GetMock();
            var courseDetailManager = new CourseDetailManager( repositoryWrapperMock.Object);

            var result = courseDetailManager.FindAll().Result;
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void GivenAnIdOfAnExistingCourseDetail_WhenGettingCourseDetailById_ThenCourseDetailReturns()
        {
            var repositoryWrapperMock = MockIRepositoryWrapper.GetMock();
            var courseDetailManager = new CourseDetailManager(repositoryWrapperMock.Object);

            var id = Guid.Parse("0f8fad5b-d9cb-469f-a165-70867728950e");
            var result = courseDetailManager.Find(id).Result ;
            Assert.NotNull(result);
        }
    }
}
