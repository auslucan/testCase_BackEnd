using CourseAPI.Test.Mocks;
using CoursesAPI.Managers;

namespace CourseAPI.Test.UnitTests
{
    public class CourseManagerTest
    {
        [Fact]
        public  void WhenGettingAllCourseThenAllCoursesReturn()
        {
            var repositoryWrapperMock = MockIRepositoryWrapper.GetMock();
            var courseManager = new CourseManager( repositoryWrapperMock.Object);

            var result =  courseManager.FindAll().Result;
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void GivenAnIdOfAnExistingCourse_WhenGettingCourseById_ThenCourseReturns()
        {
            var repositoryWrapperMock = MockIRepositoryWrapper.GetMock();
            var courseManager = new CourseManager(repositoryWrapperMock.Object);

            var id = Guid.Parse("0f8fad5b-d9cb-469f-a165-70867728950e");
            var result = courseManager.Find(id).Result ;
            Assert.NotNull(result);
        }
    }
}
