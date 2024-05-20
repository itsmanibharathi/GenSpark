namespace EmployeeRequestTracker.Models.ModelsDTOs
{
    public class GetRequestDto
    {
        public int EmployeeId { get; set; }
        public string RequestTitle { get; set; }
        public string RequestDescription { get; set; }
    }
}
