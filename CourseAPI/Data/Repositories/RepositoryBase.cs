using CoursesAPI.Data.Interfaces;
using CoursesAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CoursesAPI.Data.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected CourseContext CourseContext { get; set; }
        public RepositoryBase(CourseContext courseContext)
        {
            CourseContext = courseContext;
        }
        public IQueryable<T> FindAll() => CourseContext.Set<T>().AsNoTracking();
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return CourseContext.Set<T>().Where(expression);
        }

        public void Create(T entity) => CourseContext.Set<T>().Add(entity);
        public void Update(T entity) => CourseContext.Set<T>().Update(entity);
        public void Delete(T entity) => CourseContext.Set<T>().Remove(entity);

   
    }
}
