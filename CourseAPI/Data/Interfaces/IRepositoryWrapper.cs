namespace CoursesAPI.Data.Interfaces
{
    public interface IRepositoryWrapper
    {
        ICourseRepository CourseRepository { get; }
        ICourseDetailRepository CourseDetailRepository { get; }
        Task SaveAsync();
    }
}
