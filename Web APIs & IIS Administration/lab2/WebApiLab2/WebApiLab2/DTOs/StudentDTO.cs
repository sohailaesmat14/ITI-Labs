namespace WebApiLab2.DTOs
{
    public class StudentDTO
    {
        public int St_Id { get; set; }
        public string StFname { get; set; }
        public string StLname { get; set; }
        public int? St_Age { get; set; }
        public string DepartmentName { get; set; }
        public string SupervisorName { get; set; }
    }
}