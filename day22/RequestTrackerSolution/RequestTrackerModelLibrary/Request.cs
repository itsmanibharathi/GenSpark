using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerModelLibrary
{
    public enum RequestStatus
    {
        Open,ReOpen, Answered, Closed
    }
    public class Request
    {
        [Key]
        public int RequestNumber { get; set; }
        public string RequestMessage { get; set; }
        public DateTime RequestDate { get; set; } = System.DateTime.Now;
        public DateTime? ClosedDate { get; set; } = null;
        public RequestStatus Status { get; set; } = RequestStatus.Open;


        public int RequestRaisedBy { get; set; }
 
        public Employee RaisedByEmployee { get; set; }
        public ICollection<RequestSolution> RequestSolutions { get; set; }

        public override string ToString()
        {
            return $" Request Number: {RequestNumber}, Request Message: {RequestMessage}, Request Date: {RequestDate}, Request Status: {Status}, Request Raised By: {RequestRaisedBy}";
        }
    }
}
