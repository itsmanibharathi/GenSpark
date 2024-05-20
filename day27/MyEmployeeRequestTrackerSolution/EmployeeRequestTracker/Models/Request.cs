namespace EmployeeRequestTracker.Models
{
    public enum RequestStatus
    {
        Open,
        Pending,
        Approved,
        Rejected
    }
    public class Request
    {
        public int RequestId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public RequestStatus Status { get; set; } = RequestStatus.Pending;
        public DateTime DateOfRequest { get; set; } = DateTime.Now;
        public DateTime? DateOfCompletion { get; set; }
        public int RaisedBy { get; set; }
        public Employee RaisedByEmployee { get; set; }
        public int? SolvedBy { get; set; }
        public Employee SolvedByEmployee { get; set; }


    }
}
