using CoursesAPI.Data.Interfaces;
using CoursesAPI.Data.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseAPI.Test.Mocks
{
    public class MockIRepositoryWrapper
    {
        public static Mock<IRepositoryWrapper> GetMock()
        {
            var mock = new Mock<IRepositoryWrapper>();
            mock.Setup(m => m.CourseRepository).Returns(() => new Mock<CourseRepository>().Object);
            mock.Setup(m => m.CourseDetailRepository).Returns(() => new Mock<CourseDetailRepository>().Object);

            var courseRepoMock = MockICourseRepository.GetMock();
            var courseDetailRepoMock = MockICourseDetailRepository.GetMock();

            mock.Setup(m => m.CourseRepository).Returns(() => courseRepoMock.Object);
            mock.Setup(m => m.CourseDetailRepository).Returns(() => courseDetailRepoMock.Object);
            mock.Setup(m => m.SaveAsync()).Callback(() => { return; });
            return mock;
        }
    }
}
