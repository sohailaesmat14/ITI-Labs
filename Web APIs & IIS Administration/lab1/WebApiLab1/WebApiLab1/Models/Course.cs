namespace WebApiLab1.Models
{
    public class Course
    {
        public int ID { get; set; }
        public string Crs_name { get; set; }
        public string? crs_desc { get; set; }
        public int? Duration { get; set; }
    }
}