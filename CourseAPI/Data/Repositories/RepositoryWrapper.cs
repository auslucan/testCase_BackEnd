using CoursesAPI.Data.Interfaces;
using CoursesAPI.Models;

namespace CoursesAPI.Data.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly CourseContext _repoContext;
        private ICourseRepository _course;
        private ICourseDetailRepository _courseDetail;
        public RepositoryWrapper(CourseContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
        public ICourseRepository CourseRepository
        {
            get
            {
                _course ??= new CourseRepository(_repoContext);
                return _course;
            }
        }
        public ICourseDetailRepository CourseDetailRepository
        {
            get
            {
                _courseDetail ??= new CourseDetailRepository(_repoContext);
                return _courseDetail;
            }
        }
        public async Task SaveAsync()
        {
          await  _repoContext.SaveChangesAsync();
        }
    }
}