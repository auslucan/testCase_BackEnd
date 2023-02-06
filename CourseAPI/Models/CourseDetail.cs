namespace CoursesAPI.Models
{
    public class CourseDetail
    {
        public Guid? Id { get; set; }
        public Guid CourseId { get; set; }
        public string? CourseName { get; set; }
        public string? CourseDescription { get; set; }
        public string? CourseUrlPath { get; set; }

    }
}
