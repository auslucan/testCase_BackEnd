namespace CoursesAPI.Models
{
    public class Course
    {
        public Guid? Id { get; set; }

        public string? Name { get; set; }

        public string? StartDate { get; set; }

        public string? EndDate { get; set; }

        public bool Status { get; set; }

    }
}
