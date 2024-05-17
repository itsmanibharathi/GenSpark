namespace EmployeeRequestTrackerAPI.Models.DTOs
{
    public class GetLoginDTO :Employee
    {
        #nullable disable
        public int Id { get; set; }
        public string Password { get; set; }
    }
}
