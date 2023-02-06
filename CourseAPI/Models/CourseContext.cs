using Microsoft.EntityFrameworkCore;

namespace CoursesAPI.Models
{
    public class CourseContext:DbContext
    {
        public CourseContext(DbContextOptions<CourseContext> options):base(options)
        {

        }

        public DbSet<Course> CoursesList { get; set; } = null!;
        public DbSet<CourseDetail> CourseDetails { get; set; } = null!;

    }
}
